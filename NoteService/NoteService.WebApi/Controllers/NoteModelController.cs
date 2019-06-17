using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Dal.DataAccess.Interfaces;
using NoteService.WebApi.Models;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteModelController : ControllerBase
    {
        private readonly IDataAccess db;

        public NoteModelController(IDataAccess db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteModel>> GetAsync()
        {
            IEnumerable<Note> notes = await db.Notes.GetAllAsync();

            List<NoteModel> models = new List<NoteModel>();

            foreach(Note note in notes)
            {
                NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

                models.Add(new NoteModel { Note = note, NoteCategory = category });
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id<= 0)
            {
                return BadRequest();
            }

            Note note = await db.Notes.GetItemByIdAsync(id);

            if(note == null)
            {
                return NotFound();
            }

            NoteCategory noteCategory = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

            if(noteCategory == null)
            {
                return NotFound();
            }

            NoteModel model = new NoteModel
            {
                Note = note,
                NoteCategory = noteCategory
            };

            return Ok(model);
        }

    }
}