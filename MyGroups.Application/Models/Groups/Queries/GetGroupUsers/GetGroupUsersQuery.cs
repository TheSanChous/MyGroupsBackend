using System;
using MediatR;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupUsers
{
    public class GetGroupUsersQuery : IRequest<GroupUsersListViewModel>
    {
        public Guid GroupId { get; set; }
    }
}