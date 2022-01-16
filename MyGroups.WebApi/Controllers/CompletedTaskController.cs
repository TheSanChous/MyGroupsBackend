using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.Models.CompletedTask.Commands;

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
    }
}