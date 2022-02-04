using System;
using System.Collections.Generic;
using MediatR;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks
{
    public class GetGroupTasksQuery : IRequest<ICollection<TaskViewModel>>
    {
        public Guid GroupId { get; set; }
    }
}