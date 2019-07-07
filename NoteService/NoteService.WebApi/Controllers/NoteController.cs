using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Mvc;
using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.WebApi.Models;
using NotesService.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public NoteController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteModel>> Get()
        {
            IEnumerable<Note> notes = await db.Sort.GetItemsByLastChangedAsync();

            List<NoteModel> models = new List<NoteModel>();

            foreach(var note in notes)
            {
                NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

                models.Add(new NoteModel { Note = note, NoteCategory = category });
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            Note note = await db.Notes.GetItemByIdAsync(id);

            if(note == null)
            {
                return NotFound();
            }

            NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

            NoteModel model = new NoteModel
            {
                Note = note,
                NoteCategory = category
            };

            return Ok(model);
        } 

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateNote model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            Note note = await db.Notes.CreateAsync(mapper.Map<Note>(model));

            EditNote newModel = mapper.Map<EditNote>(note);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditNote model)
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

            await db.Notes.UpdateAsync(mapper.Map<Note>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Note note = await db.Notes.GetItemByIdAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            await db.Notes.DeleteAsync(note.Id);

            EditNote model = mapper.Map<EditNote>(note);

            return Ok(model);
        }
    }
}