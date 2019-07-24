using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Mvc;
using NoteService.PL;
using NotesService.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteCategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public NoteCategoryController(IPresenterLayer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCategory>> Get()
        {
            return await db.NoteCategories.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            NoteCategory category = await db.NoteCategories.GetItemByIdAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateNoteCategory model)
        {
            NoteCategory noteCategory;

            if (model == null)
            {
                noteCategory = await db.NoteCategories.CreateAsync(NoteServiceDefaultValues.DefaultNoteCategories.NoteCategory);

                return Ok(noteCategory);
            }

            noteCategory = await db.NoteCategories.CreateAsync(NoteServiceDefaultValues.DefaultNoteCategories.VerificationAndCorrectioDataForCreating(mapper.Map<NoteCategory>(model)));

            return Ok(noteCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]NoteCategory category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            await db.NoteCategories.UpdateAsync(NoteServiceDefaultValues.DefaultNoteCategories.VerificationAndCorrectioDataForEdit(category));

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            NoteCategory noteCategory = await db.NoteCategories.GetItemByIdAsync(id);

            if (noteCategory == null)
            {
                return NotFound();
            }

            IEnumerable<Note> notes = await db.Notes.GetByNoteCategoryIdAsync(id);

            if ((notes.ToList()).Count != 0)
            {
                foreach(var note in notes)
                {
                    await db.Notes.DeleteAsync(note.Id);
                }
            }
            await db.NoteCategories.DeleteAsync(noteCategory.Id);

            return Ok();
        }
    }
}