using System;
using MediatR;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupUsers
{
    public class GetGroupUsersQuery : IRequest<GroupUsersListViewModel>
    {
        public Guid GroupId { get; set; }
    }
}