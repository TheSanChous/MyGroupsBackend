using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Commands.JoinGroup
{
    public class JoinGroupCommand : IRequest
    {
        public string GroupIdentifier { get; set; }
    }
}
