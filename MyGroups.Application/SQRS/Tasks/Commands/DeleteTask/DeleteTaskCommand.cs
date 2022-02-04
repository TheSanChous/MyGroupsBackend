using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid TaskId { get; set; }
    }
}
