using AutoMapper;
using Common.Entity.NoteService;
using Microsoft.AspNetCore.Mvc;
using NoteService.Bll.BusinessLogic.Interfaces;
using NotesService.WebApi.Models;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await db.NoteCategories.GetAllAsync());
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
                return BadRequest();
            }

            await db.NoteCategories.DeleteAsync(noteCategory.Id);

            EditNoteCategory model = mapper.Map<EditNoteCategory>(noteCategory);

            return Ok(model);
        }
    }
}