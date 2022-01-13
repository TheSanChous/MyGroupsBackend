using MediatR;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetRoleInGroup
{
    public class GetRoleInGroupQuery : IRequest<UserRolesInGroup>
    {
        public Guid GroupId { get; set; }
    }
}
