using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyGroups.Application.SQRS.CompletedTask.Commands
{
    public class CreateCompletedTaskCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public IFormFile File { get; set; }
    }
}