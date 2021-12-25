using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
