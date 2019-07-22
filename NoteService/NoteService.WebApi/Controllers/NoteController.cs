﻿using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Mvc;
using NoteService.PL;
using NotesService.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public NoteController(IPresenterLayer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCard>> Get()
        {
            return await db.Cards.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            NoteCard card = await db.Cards.GetItemByIdAsync(id);

            if(card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            NoteCard card = await db.Cards.CreateAsync(NoteServiceDefaultValues.DefaultNote.Note);

            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateNote model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            NoteCard card = await db.Cards.CreateAsync(mapper.Map<Note>(model));

            return Ok(card);
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

            NoteCard card = await db.Cards.UpdateAsync(mapper.Map<Note>(model));

            return Ok(card);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Note note = await db.Notes.DeleteAsync(id);

            if(note == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}