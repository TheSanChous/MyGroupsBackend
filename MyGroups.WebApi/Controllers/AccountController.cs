using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.Models.Users.Queries.GetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserInfoViewModel>> GetUserInfo(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetUserInfoQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
