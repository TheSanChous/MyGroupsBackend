using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.AppendFile
{
    public class CompletedTaskAppendFileCommand : IRequest
    {
        public Guid ComplatedTaskId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
