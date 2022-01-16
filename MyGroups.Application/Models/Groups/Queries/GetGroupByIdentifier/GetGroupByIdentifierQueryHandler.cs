using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Application.Models.Groups.Queries.GetGroup;
using MyGroups.Application.Models.Groups.Queries.GetGroupList;
using MyGroups.Domain.Models.Users;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupByIdentifier
{
    public class GetGroupByIdentifierQueryHandler : IRequestHandler<GetGroupByIdentifierQuery, GroupViewModel>
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public GetGroupByIdentifierQueryHandler(IDatabaseContext databaseContext,
            IAuthorizationService authorizationService,
            IMapper mapper)
        {
            _databaseContext = databaseContext;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<GroupViewModel> Handle(GetGroupByIdentifierQuery request, CancellationToken cancellationToken)
        {
            var user = _authorizationService.CurrentUser;

            var userGroup = await _databaseContext.UsersGroups
                .Include(userGroup => userGroup.Group)
                .Include(userGroup => userGroup.User)
                .FirstOrDefaultAsync(userGroup =>
                        userGroup.Group.Identifier == request.GroupIdentifier && userGroup.User == user,
                    cancellationToken);

            return _mapper.Map<GroupViewModel>(userGroup.Group);
        }
    }
}