using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Dal.DataAccess.Interfaces;
using NotesService.WebApi.Models;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteCategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDataAccess db;

        public NoteCategoryController(IMapper mapper, IDataAccess db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<EditNoteCategory>> Get()
        {
            var notes = await db.NoteCategories.GetAllAsync();

            List<EditNoteCategory> models = mapper.Map<List<EditNoteCategory>>(notes);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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

            EditNoteCategory model = mapper.Map<EditNoteCategory>(noteCategory);

            if (model == null)
            {
                return NotFound();
            }

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
                return BadRequest();
            }

            await db.NoteCategories.DeleteAsync(noteCategory.Id);

            EditNoteCategory model = mapper.Map<EditNoteCategory>(noteCategory);

            return Ok(model);
        }
    }
}