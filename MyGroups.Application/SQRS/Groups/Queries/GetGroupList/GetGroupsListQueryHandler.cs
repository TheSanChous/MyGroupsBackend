using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Application.SQRS.Groups.Queries.GetGroup;
using MyGroups.Domain.Models.Groups;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupList
{
    public class GetGroupsListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListViewModel>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper mapper;

        public GetGroupsListQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            _authorizationService = authorizationService;
            this.mapper = mapper;
        }

        public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            UserGroup[] groupsQuery = await databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .Where(group => group.User == user)
                .ToArrayAsync(cancellationToken);

            var result = groupsQuery
                .Select(group => mapper.Map<GroupViewModel>(group.Group))
                .ToList();

            return new GroupListViewModel
            {
                Groups = result
            };
        }
    }
}
