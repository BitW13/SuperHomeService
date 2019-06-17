using Common.Entity.NoteService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NoteService.Bll.BusinessLogic.Interfaces;
using NoteService.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteModelController : ControllerBase
    {
        private readonly IBusinessLogic db;

        public NoteModelController(IBusinessLogic db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteModel>> Get()
        {
            IEnumerable<Note> notes = await db.Sort.GetNotesByLastChangedAsync();

            List<NoteModel> models = new List<NoteModel>();

            foreach (Note note in notes)
            {
                NoteCategory category = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

                models.Add(new NoteModel { Note = note, NoteCategory = category });
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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

            NoteCategory noteCategory = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

            if (noteCategory == null)
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