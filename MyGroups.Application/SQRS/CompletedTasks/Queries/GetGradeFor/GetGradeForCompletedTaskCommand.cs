using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.CompletedTasks.Queries.GetGradeFor
{
    public class GetGradeForCompletedTaskCommand : IRequest<GradeViewModel>
    {
        public Guid CompletedTaskId { get; set; }
    }
}
