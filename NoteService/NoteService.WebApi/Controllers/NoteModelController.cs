using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Mvc;
using NoteService.Dal.DataAccess.Interfaces;
using NoteService.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteModelController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDataAccess db;

        public NoteModelController(IMapper mapper, IDataAccess db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteModel>> Get()
        {
            var notes = await db.Notes.GetAllAsync();

            List<NoteModel> models = new List<NoteModel>();

            foreach(var note in notes)
            {
                NoteModel noteModel = new NoteModel();

                noteModel.Note = note;

                noteModel.NoteCategory = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId);

                models.Add(noteModel);
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

            NoteModel model = new NoteModel
            {
                Note = note,
                NoteCategory = await db.NoteCategories.GetItemByIdAsync(note.NoteCategoryId)
            };

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}