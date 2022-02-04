using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.LeaveGroup
{
    public class LeaveGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
    }
}
