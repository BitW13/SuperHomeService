using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.PL;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public TaskController(IPresenterLayer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskCard>> Get()
        {
            return await db.Cards.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCard card = await db.Cards.GetItemByIdAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTask model)
        {
            TaskCard card;

            if (model == null)
            {
                card = await db.Cards.CreateAsync(TaskPlannerServiceDefaultValues.DefaultTask.Task);

                return Ok(card);
            }

            card = await db.Cards.CreateAsync(TaskPlannerServiceDefaultValues.DefaultTask.VerificationAndCorrectionDataForCreating(mapper.Map<TaskEntity>(model)));

            return Ok(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TaskEntity model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            TaskCard card = await db.Cards.UpdateAsync(TaskPlannerServiceDefaultValues.DefaultTask.VerificationAndCorrectionDataForEdit(model));

            return Ok(card);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await db.Tasks.DeleteAsync(id);

            return Ok();
        }
    }
}