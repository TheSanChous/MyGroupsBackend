using System;
using MediatR;

namespace MyGroups.Application.Models.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsViewModel>
    {
        public Guid TaskId { get; set; }
    }
}