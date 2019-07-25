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
    public class TaskCategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPresenterLayer db;

        public TaskCategoryController(IMapper mapper, IPresenterLayer db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskCategory>> Get()
        {
            return await db.TaskCategories.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCategory category = await db.TaskCategories.GetItemByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTaskCategory model)
        {
            TaskCategory category;

            if (model == null)
            {
                category = await db.TaskCategories.CreateAsync(TaskPlannerServiceDefaultValues.DefaultTaskCategories.TaskCategory);

                return Ok(category);
            }

            category = await db.TaskCategories.CreateAsync(TaskPlannerServiceDefaultValues.DefaultTaskCategories.VerificationAndCorrectionDataForCreating(mapper.Map<TaskCategory>(model)));

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TaskCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            await db.TaskCategories.UpdateAsync(TaskPlannerServiceDefaultValues.DefaultTaskCategories.VerificationAndCorrectionDataForEdit(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCategory category = await db.TaskCategories.GetItemByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            IEnumerable<TaskEntity> tasks = await db.Tasks.GetByTaskCategoryIdAsync(id);

            if ((tasks.ToList()).Count != 0)
            {
                foreach (var task in tasks)
                {
                    task.TaskCategoryId = TaskPlannerServiceDefaultValues.DefaultTask.Task.TaskCategoryId;
                    await db.Tasks.UpdateAsync(task);
                }
            }
            await db.TaskCategories.DeleteAsync(category.Id);

            return Ok();
        }
    }
}