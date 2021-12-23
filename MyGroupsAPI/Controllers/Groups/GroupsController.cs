using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGroupsAPI.Models.Groups;
using MyGroupsAPI.Services.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Controllers.Groups
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet("{id}")]
        public IActionResult GetGroup([FromRoute] Guid id)
        {
            var group = groupService.GetGroup(id);

            return Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await groupService.GetGroupsAsync();

            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupModel createGroupModel)
        {
            await groupService.CreateGroupAsync(createGroupModel);

            return Ok();
        }

        [HttpPost("join/{id}")]
        public async Task<IActionResult> JoinGroup(Guid id)
        {
            await groupService.JoinGroupAsync(id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            await groupService.DeleteGroupAsync(id);

            return Ok();
        }
    }
}
