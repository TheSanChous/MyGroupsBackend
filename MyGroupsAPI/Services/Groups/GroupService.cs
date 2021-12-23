using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using MyGroupsAPI.Exceptions;
using MyGroupsAPI.Models.Groups;
using MyGroupsAPI.Services.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Groups
{
    public class GroupService : IGroupService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IAuthorizationService authorizationService;

        public GroupService(DatabaseContext databaseContext,
            IAuthorizationService authorizationService)
        {
            this.databaseContext = databaseContext;
            this.authorizationService = authorizationService;
        }
        public async System.Threading.Tasks.Task CreateGroupAsync(CreateGroupModel createGroupModel)
        {
            User user = authorizationService.CurrentUser;

            var schelude = new Schelude();

            var group = new Group
            {
                Title = createGroupModel.Title,
                Description = createGroupModel.Description,
                Schelude = schelude
            };

            schelude.Group = group;
            schelude.GroupId = group.Id;

            var userGroup = new UserGroup
            {
                Group = group,
                User = user,
                RoleInGroup = databaseContext.RoleUserInGroups.Single(role => role.Title == "Admin")
            };

            await databaseContext.Groups.AddAsync(group);
            await databaseContext.Scheludes.AddAsync(schelude);
            await databaseContext.UserGroups.AddAsync(userGroup);

            await databaseContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteGroupAsync(Guid id)
        {
            var user = authorizationService.CurrentUser;

            var userGroup = databaseContext.UserGroups
                .Include(ug => ug.Group)
                .Include(ug => ug.User)
                .Include(ug => ug.RoleInGroup)
                .SingleOrDefault(
                userGroup => userGroup.User == user &&
                userGroup.Group.Id == id
                );


            if(userGroup is null)
            {
                throw new ServiceException("Group not found");
            }

            if(userGroup.RoleInGroup.Title != "Admin")
            {
                throw new ServiceException("Access denied");
            }

            var groupsToRemove = databaseContext.UserGroups.Where(ug => ug.Group == userGroup.Group);

            if (groupsToRemove.Any())
            {
                databaseContext.UserGroups.RemoveRange(groupsToRemove);
            }

            databaseContext.Groups.Remove(userGroup.Group);

            await databaseContext.SaveChangesAsync();
        }

        public async Task<Group> GetGroup(Guid id)
        {
            var user = authorizationService.CurrentUser;

            var userGroup = databaseContext.UserGroups
                .Include(ug => ug.Group)
                    .ThenInclude(g => g.Publications)
                .Include(ug => ug.Group)
                    .ThenInclude(g => g.Schelude)
                .SingleOrDefault(
                userGroup => userGroup.User == user &&
                userGroup.Group.Id == id
            );

            if(userGroup is null)
            {
                throw new ServiceException("Group not found");
            }

            return userGroup.Group;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var user = authorizationService.CurrentUser;

            var groups = databaseContext.UserGroups
                .Include(ug => ug.Group)
                    .ThenInclude(g => g.Publications)
                .Include(ug => ug.Group)
                    .ThenInclude(g => g.Schelude)
                .Where(ug => ug.User == user)
                .Select(ug => ug.Group);

            return groups;
        }

        public async System.Threading.Tasks.Task JoinGroupAsync(Guid id)
        {
            var user = authorizationService.CurrentUser;

            var group = databaseContext.Groups.SingleOrDefault(g => g.Id == id);

            if (group is null)
            {
                throw new ServiceException("User in group");
            }

            var userGroup = new UserGroup
            {
                User = user,
                Group = group,
                RoleInGroup = databaseContext.RoleUserInGroups.Single(role => role.Title == "Member")
            };

            await databaseContext.UserGroups.AddAsync(userGroup);

            await databaseContext.SaveChangesAsync();
        }
    }
}
