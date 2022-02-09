using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.SQRS.CompletedTasks.Commands.AppendFile;
using MyGroups.Application.SQRS.CompletedTasks.Commands.CreateComplatedTask;
using MyGroups.Application.SQRS.CompletedTasks.Commands.EstimateCompletedTask;
using MyGroups.Application.SQRS.CompletedTasks.Queries.GetComplatedFor;
using MyGroups.Application.SQRS.CompletedTasks.Queries.GetGradeFor;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Controllers
{
    public class CompletedTaskController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> UploadTask([FromBody] CreateCompletedTaskCommand command, CancellationToken cancellationToken)
        {
            var taskId = await Mediator.Send(command, cancellationToken);

            return Ok(new
            {
                TaskId = taskId
            });
        }

        [HttpPost("{id}/file")]
        public async Task<ActionResult> UploadTask([FromRoute] Guid id, IFormFile file, CancellationToken cancellationToken)
        {

            var taskId = await Mediator.Send(new CompletedTaskAppendFileCommand
            {
                ComplatedTaskId = id,
                FormFile = file
               
            }, cancellationToken);

            return Ok(new
            {
                TaskId = taskId
            });
        }

        [HttpPost("grade")]
        public async Task<ActionResult> EstimateTask([FromBody] EstimateCompletedTaskCommand command , CancellationToken cancellationToken)
        {

            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}/grade")]
        public async Task<ActionResult<GradeViewModel>> GetGrade([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            var grade = await Mediator.Send(new GetGradeForCompletedTaskCommand
            {
                CompletedTaskId = id
            }, cancellationToken);

            return Ok(grade);
        }

        [HttpGet]
        [Route("task/{taskId}")]
        public async Task<ActionResult<ICollection<CompletedTaskViewModel>>> GetCompletedTasks([FromRoute] Guid taskId)
        {
            var result = await Mediator.Send(new GetComplatedTasksForTaskCommand
            {
                TaskId = taskId
            });

            return Ok(result);
        }
    }
}