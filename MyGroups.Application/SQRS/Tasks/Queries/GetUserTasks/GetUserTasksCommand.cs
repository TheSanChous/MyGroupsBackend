using MediatR;
using MyGroups.Application.SQRS.Tasks.Queries.GetGroupTasks;
using System.Collections.Generic;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetUserTasks
{
    public class GetUserTasksCommand : IRequest<ICollection<TaskViewModel>>
    {
    }
}
