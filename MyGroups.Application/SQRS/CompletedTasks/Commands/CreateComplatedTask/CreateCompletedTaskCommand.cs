using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.CreateComplatedTask
{
    public class CreateCompletedTaskCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public IFormFile File { get; set; }
    }
}