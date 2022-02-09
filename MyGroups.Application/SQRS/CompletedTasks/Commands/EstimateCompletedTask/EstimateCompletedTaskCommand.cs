using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Commands.EstimateCompletedTask
{
    public class EstimateCompletedTaskCommand : IRequest<Unit>
    {
        public Guid CompletedTaskId { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
