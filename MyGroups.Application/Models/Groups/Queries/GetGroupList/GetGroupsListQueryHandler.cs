using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Application.Models.Groups.Queries.GetGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupList
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
            
            var groupsQuery = await databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .Where(group => group.User == user)
                .Select(group => group.Group)
                .ProjectTo<GroupViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GroupListViewModel
            {
                Groups = groupsQuery
            };
        }
    }
}
