using AutoMapper;
using Common.Entity.TaskPlannerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public TaskController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskCard>> Get()
        {
            IEnumerable<TaskEntity> tasks = await db.Tasks.GetAllAsync();

            List<TaskCard> models = new List<TaskCard>();

            foreach (TaskEntity task in tasks)
            {
                TaskCategory category = await db.TaskCategories.GetItemByIdAsync(task.TaskCategoryId);

                models.Add(new TaskCard { Task = task, TaskCategory = category });
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
            TaskEntity task = await db.Tasks.GetItemByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            TaskCategory category = await db.TaskCategories.GetItemByIdAsync(task.TaskCategoryId);

            TaskCard model = new TaskCard
            {
                Task = task,
                TaskCategory = category
            };

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTask model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            TaskEntity task = await db.Tasks.CreateAsync(mapper.Map<TaskEntity>(model));

            EditTask newModel = mapper.Map<EditTask>(task);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EditTask model)
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

            await db.Tasks.UpdateAsync(mapper.Map<TaskEntity>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            TaskEntity note = await db.Tasks.GetItemByIdAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            await db.Tasks.DeleteAsync(note.Id);

            EditTask model = mapper.Map<EditTask>(note);

            return Ok(model);
        }
    }
}