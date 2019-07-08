using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public TaskCategoryController(IMapper mapper, IBusinessLogic db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<EditTaskCategory>> Get()
        {
            IEnumerable<TaskCategory> taskCategories = await db.TaskCategories.GetAllAsync();

            IEnumerable<EditTaskCategory> models = mapper.Map<IEnumerable<EditTaskCategory>>(taskCategories);

            return models;
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

            EditTaskCategory model = mapper.Map<EditTaskCategory>(category);

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTaskCategory model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            model.IsOn = true;

            TaskCategory taskCategory = await db.TaskCategories.CreateAsync(mapper.Map<TaskCategory>(model));

            EditTaskCategory newModel = mapper.Map<EditTaskCategory>(taskCategory);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditTaskCategory model)
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

            await db.TaskCategories.UpdateAsync(mapper.Map<TaskCategory>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskCategory taskCategory = await db.TaskCategories.GetItemByIdAsync(id);

            if (taskCategory == null)
            {
                return NotFound();
            }

            IEnumerable<TaskEntity> tasks = await db.Tasks.GetByTaskCategoryIdAsync(id);
            if ((tasks.ToList()).Count != 0)
            {
                foreach (var task in tasks)
                {
                    await db.Tasks.DeleteAsync(task.Id);
                }
            }
            await db.TaskCategories.DeleteAsync(taskCategory.Id);

            EditTaskCategory model = mapper.Map<EditTaskCategory>(taskCategory);

            return Ok(model);
        }
    }
}