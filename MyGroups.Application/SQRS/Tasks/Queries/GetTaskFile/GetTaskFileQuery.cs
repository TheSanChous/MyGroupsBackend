using System;
using System.IO;
using MediatR;

namespace MyGroups.Application.SQRS.Tasks.Queries.GetTaskFile
{
    public class GetTaskFileQuery : IRequest<FileViewModel>
    {
        public Guid TaskId { get; set; }
    }
}