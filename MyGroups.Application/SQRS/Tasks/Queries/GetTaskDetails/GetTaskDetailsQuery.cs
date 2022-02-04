using System;
using MediatR;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsViewModel>
    {
        public Guid TaskId { get; set; }
    }
}