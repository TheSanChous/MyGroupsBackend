using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid GroupId { get; set; }
    }
}
