using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupList
{
    public class GetGroupListQuery : IRequest<GroupListViewModel>
    {
        public Guid Id { get; set; }
    }
}
