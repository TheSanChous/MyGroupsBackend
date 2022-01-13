using Microsoft.AspNetCore.Mvc;
using MyGroups.Application.Models.Groups.Commands.CreateGroup;
using MyGroups.Application.Models.Groups.Commands.JoinGroup;
using MyGroups.Application.Models.Groups.Commands.LeaveGroup;
using MyGroups.Application.Models.Groups.Queries.GetGroup;
using MyGroups.Application.Models.Groups.Queries.GetGroupList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyGroups.Application.Models.Groups.Queries.GetGroupUsers;
using MyGroups.Domain.Models.Groups;
using MyGroups.Application.Models.Groups.Queries.GetRoleInGroup;
using MyGroups.Application.Models.Tasks.Queries.GetGroupTasks;

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
        public async Task<ActionResult<GroupViewModel>> Get([FromRoute] Guid id)
        {
            var query = new GetGroupQuery
            {
                Id = id
            };

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateGroupCommand createGroupCommand)
        {
            Guid groupId = await Mediator.Send(createGroupCommand);

            return Ok(groupId);
        }

        [HttpGet]
        [Route("{id}/join")]
        public async Task<ActionResult> Join([FromRoute] Guid id)
        {
            var command = new JoinGroupCommand
            {
                GroupId = id
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/leave")]
        public async Task<ActionResult> Leave([FromRoute] Guid id)
        {
            var command = new LeaveGroupCommand
            {
                GroupId = id
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/members")]
        public async Task<ActionResult<GroupUsersListViewModel>> GetMembers([FromRoute] Guid id)
        {
            var command = new GetGroupUsersQuery
            {
                GroupId = id
            };

            var groupUsersListViewModel = await Mediator.Send(command);

            return Ok(groupUsersListViewModel);
        }
        
        [HttpGet]
        [Route("{id}/tasks")]
        public async Task<ActionResult<ICollection<TaskViewModel>>> GetGroupTasks([FromRoute] Guid id)
        {
            var query = new GetGroupTasksQuery
            {
                GroupId = id
            };

            var tasks = await Mediator.Send(query);

            return Ok(tasks);
        }
        
        [HttpGet]
        [Route("{id}/role")]
        public async Task<ActionResult> GetRole([FromRoute] Guid id)
        {
            var query = new GetRoleInGroupQuery
            {
                GroupId = id
            };

            var role = await Mediator.Send(query);

            var response = new
            {
                role = Enum.GetName(role)
            };

            return Ok(response);
        }
    }
}
