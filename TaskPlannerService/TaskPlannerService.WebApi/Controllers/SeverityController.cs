using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlannerService.PL;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public SeverityController(IMapper mapper, IPresenterLayer db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Severity>> Get()
        {
            return await db.Severities.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Severity severity = await db.Severities.GetItemByIdAsync(id);

            if (severity == null)
            {
                return NotFound();
            }

            return Ok(severity);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSeverity model)
        {
            Severity severity;

            if (model == null)
            {
                severity = await db.Severities.CreateAsync(TaskPlannerServiceDefaultValues.DefaultSeverity.Severity);

                return Ok(severity);
            }

            severity = await db.Severities.CreateAsync(TaskPlannerServiceDefaultValues.DefaultSeverity.VerificationAndCorrectionDataForCreating(mapper.Map<Severity>(model)));

            return Ok(severity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Severity model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            await db.Severities.UpdateAsync(TaskPlannerServiceDefaultValues.DefaultSeverity.VerificationAndCorrectionDataForEdit(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Severity severity = await db.Severities.GetItemByIdAsync(id);

            if (severity == null)
            {
                return NotFound();
            }

            IEnumerable<TaskEntity> tasks = await db.Tasks.GetBySeverityIdAsync(id);

            if ((tasks.ToList()).Count != 0)
            {
                foreach (var task in tasks)
                {
                    task.SeverityId = TaskPlannerServiceDefaultValues.DefaultTask.Task.SeverityId;
                    await db.Tasks.UpdateAsync(task);
                }
            }
            await db.Severities.DeleteAsync(severity.Id);

            return Ok();
        }
    }
}