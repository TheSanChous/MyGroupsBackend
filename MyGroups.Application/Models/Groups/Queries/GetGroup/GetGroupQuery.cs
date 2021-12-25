using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetGroup
{
    public class GetGroupQuery : IRequest<GroupViewModel>
    {
        public Guid Id { get; set; }
    }
}
