using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyGroups.Application.SQRS.Tasks.Commands.AppendFileTask
{
    public class AppendFileTaskCommand : IRequest<Unit>
    {
        public Guid TaskId { get; set; }
        public IFormFile File { get; set; }
    }
}