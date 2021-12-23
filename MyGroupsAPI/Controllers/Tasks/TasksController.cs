using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroupsAPI.Models.Tasks;
using MyGroupsAPI.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await taskService.GetTasks();

            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTasks([FromRoute] Guid taskId)
        {
            var task = await taskService.GetTask(taskId);

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskModel createTaskModel)
        {
            await taskService.CreateTask(createTaskModel);

            return Ok();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> CreateTask([FromRoute] Guid taskId)
        {
            await taskService.DeleteTask(taskId);

            return Ok();
        }
    }
}
