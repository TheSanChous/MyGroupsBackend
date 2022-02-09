using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Queries.GetComplatedFor
{
    public class GetComplatedTasksForTaskCommand : IRequest<ICollection<CompletedTaskViewModel>>
    {
        public Guid TaskId { get; set; }
    }
}
