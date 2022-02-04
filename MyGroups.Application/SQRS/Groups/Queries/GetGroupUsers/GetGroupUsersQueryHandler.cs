using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using MyGroups.Infrastructure.Abstractions;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupUsers
{
    public class GetGroupUsersQueryHandler : IRequestHandler<GetGroupUsersQuery, GroupUsersListViewModel>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;

        public GetGroupUsersQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
        }
        
        public async Task<GroupUsersListViewModel> Handle(GetGroupUsersQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var currentUserGroup = await _databaseContext.UsersGroups
                .FirstOrDefaultAsync(userGroup => userGroup.User == user && userGroup.Group.Id == request.GroupId,
                    cancellationToken);

            if (currentUserGroup is null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var groupUserViewModels = _databaseContext.UsersGroups
                .Include(userGroup => userGroup.User)
                .Where(userGroup => userGroup.User != user && userGroup.Group.Id == request.GroupId)
                .Select(userGroup => new GroupUserViewModel
                {
                    Name = userGroup.User.Name,
                    Surname = userGroup.User.Surname,
                    Email = userGroup.User.Email,
                    Role = userGroup.Role.ToString()
                }).ToList();

            return new GroupUsersListViewModel
            {
                GroupUsersList = groupUserViewModels
            };
        }
    }
}