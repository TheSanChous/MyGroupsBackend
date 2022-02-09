using AutoMapper;
using MediatR;
using MyGroups.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Users.Queries.GetInfo
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoViewModel>
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IMapper mapper;

        public GetUserInfoQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper)
        {
            this.authorizationService = authorizationService;
            this.mapper = mapper;
        }

        public async Task<UserInfoViewModel> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = authorizationService.CurrentUser;

            return mapper.Map<UserInfoViewModel>(user);
        }
    }
}
