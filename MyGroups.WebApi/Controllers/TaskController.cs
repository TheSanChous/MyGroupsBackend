using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.SQRS.Tasks.Commands.CreateTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks;
using MyGroups.Application.SQRS.Tasks.Commands.AppendFileTask;
using MyGroups.Application.SQRS.Tasks.Commands.DeleteTask;
using MyGroups.Application.SQRS.Tasks.Queries.GetTaskDetails;
using MyGroups.Application.SQRS.Tasks.Queries.GetTaskFile;
using MyGroups.Application.SQRS.Tasks.Queries.GetUserTasks;

namespace MyGroups.WebApi.Controllers
{
    public class TaskController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskViewModel>>> GetTasks()
        {
            var tasks = await Mediator.Send(new GetUserTasksCommand());

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TaskDetailsViewModel>> GetTaskDetails([FromRoute] Guid id)
        {
            var query = new GetTaskDetailsQuery
            {
                TaskId = id
            };

            var task = await Mediator.Send(query);

            return Ok(task);
        }
        
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] CreateTaskCommand createTaskCommand, CancellationToken cancellationToken)
        {
            var taskId = await Mediator.Send(createTaskCommand, cancellationToken);

            return Ok(taskId);
        }

        [HttpPost]
        [Route("{id}/file")]
        public async Task<ActionResult> AppendFile([FromRoute] Guid id, IFormFile file, CancellationToken cancellationToken)
        {
            var command = new AppendFileTaskCommand
            {
                TaskId = id,
                File = file
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }
        
        [HttpGet]
        [Route("{id}/file")]
        public async Task<ActionResult<FileViewModel>> GetFile([FromRoute] Guid id)
        {
            var query = new GetTaskFileQuery
            {
                TaskId = id
            };

            var file = await Mediator.Send(query);

            return Ok(file);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTask([FromRoute] Guid id)
        {
            var command = new DeleteTaskCommand
            {
                TaskId = id
            };

            await Mediator.Send(command);

            return Ok();
        }

    }
}
