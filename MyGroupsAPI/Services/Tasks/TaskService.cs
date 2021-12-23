using Data;
using Data.Models;
using MyGroupsAPI.Exceptions;
using MyGroupsAPI.Models.Tasks;
using MyGroupsAPI.Services.Authorization;
using MyGroupsAPI.Services.Files;
using MyGroupsAPI.Services.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly DatabaseContext databaseContex;
        private readonly IAuthorizationService authorizationService;
        private readonly IGroupService groupService;
        private readonly IFileService fileService;

        public TaskService(DatabaseContext databaseContex,
            IAuthorizationService authorizationService,
            IGroupService groupService,
            IFileService fileService
            )
        {
            this.databaseContex = databaseContex;
            this.authorizationService = authorizationService;
            this.groupService = groupService;
            this.fileService = fileService;
        }

        public async System.Threading.Tasks.Task CreateTask(CreateTaskModel createTaskModel)
        {
            User user = authorizationService.CurrentUser;

            var task = new Data.Models.Task
            {
                Title = createTaskModel.Title,
                Description = createTaskModel.Description,
                Customer = user,
                Deadline = createTaskModel.Deadline,
                File = await fileService.GetFile(createTaskModel.FileId),
                Group = await groupService.GetGroup(createTaskModel.GroupId),
                LoadedAt = DateTime.Now
            };

            await databaseContex.Tasks.AddAsync(task);

            await databaseContex.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteTask(Guid taskId)
        {
            User user = authorizationService.CurrentUser;

            var task = await GetTask(taskId);

            databaseContex.Remove(task);

            await databaseContex.SaveChangesAsync();
        }

        public async Task<Data.Models.Task> GetTask(Guid taskId)
        {
            User user = authorizationService.CurrentUser;

            var task = databaseContex.Tasks
                .Where(task => task.Customer == user)
                .SingleOrDefault(task => task.Id == taskId);

            if(task is null)
            {
                throw new ServiceException("Task not found");
            }

            return task;
        }

        public async Task<IEnumerable<Data.Models.Task>> GetTasks()
        {
            User user = authorizationService.CurrentUser;

            var tasks = databaseContex.Tasks
                .Where(task => task.Customer == user);

            return tasks;
        }
    }
}
