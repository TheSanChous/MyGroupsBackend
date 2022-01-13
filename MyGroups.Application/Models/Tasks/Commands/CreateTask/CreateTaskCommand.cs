using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid GroupId { get; set; }
    }
}
