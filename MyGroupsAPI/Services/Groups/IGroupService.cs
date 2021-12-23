using Data.Models;
using MyGroupsAPI.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Groups
{
    public interface IGroupService
    {
        public Task<IEnumerable<Group>> GetGroupsAsync();
        public Task<Group> GetGroup(Guid Id);
        public System.Threading.Tasks.Task CreateGroupAsync(CreateGroupModel createGroupModel);
        public System.Threading.Tasks.Task JoinGroupAsync(Guid Id);
        public System.Threading.Tasks.Task DeleteGroupAsync(Guid Id);
    }
}
