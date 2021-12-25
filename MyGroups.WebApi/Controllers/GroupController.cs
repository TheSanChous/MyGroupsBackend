using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.Models.Groups.Commands.CreateGroup;
using MyGroups.Application.Models.Groups.Commands.JoinGroup;
using MyGroups.Application.Models.Groups.Commands.LeaveGroup;
using MyGroups.Application.Models.Groups.Queries.GetGroup;
using MyGroups.Application.Models.Groups.Queries.GetGroupList;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Controllers
{ 
    public class GroupController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GroupListViewModel>> GetAll()
        {
            var query = new GetGroupListQuery
            {
                Id = Guid.Empty
            };

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GroupListViewModel>> Get([FromRoute] Guid id)
        {
            var query = new GetGroupQuery
            {
                Id = id
            };

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateGroupCommand createGroupCommand)
        {
            await Mediator.Send(createGroupCommand);

            return Ok();
        }

        [HttpPost]
        [Route("join/{id}")]
        public async Task<ActionResult> Join([FromRoute] Guid id)
        {
            var command = new JoinGroupCommand
            {
                GroupId = id
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("leave/{id}")]
        public async Task<ActionResult> Leave([FromRoute] Guid id)
        {
            var command = new LeaveGroupCommand
            {
                GroupId = id
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
