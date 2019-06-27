using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NoteService.Bll.BusinessLogic.Interfaces;
using NotesService.WebApi.Models;
using System.Collections;
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
        private readonly IBusinessLogic db;

        public NoteCategoryController(IMapper mapper, IBusinessLogic db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<EditNoteCategory>> Get()
        {
            IEnumerable<NoteCategory> noteCategories = await db.NoteCategories.GetAllAsync();

            IEnumerable<EditNoteCategory> models = mapper.Map<IEnumerable<EditNoteCategory>>(noteCategories);

            return models;
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

            EditNoteCategory model = mapper.Map<EditNoteCategory>(category);

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateNoteCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            model.IsOn = true;

            NoteCategory noteCategory = await db.NoteCategories.CreateAsync(mapper.Map<NoteCategory>(model));

            EditNoteCategory newModel = mapper.Map<EditNoteCategory>(noteCategory);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditNoteCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            await db.NoteCategories.UpdateAsync(mapper.Map<NoteCategory>(model));

            return Ok(model);
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

            EditNoteCategory model = mapper.Map<EditNoteCategory>(noteCategory);

            return Ok(model);
        }
    }
}