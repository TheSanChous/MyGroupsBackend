using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Models;
using MyGroupsAPI.Models.Tasks;

namespace MyGroupsAPI.Services.Tasks
{
    public interface ITaskService
    {
        public System.Threading.Tasks.Task CreateTask(CreateTaskModel createTaskModel);
        public System.Threading.Tasks.Task DeleteTask(Guid taskId);
        public System.Threading.Tasks.Task<Data.Models.Task> GetTask(Guid taskId);
        public Task<IEnumerable<Data.Models.Task>> GetTasks();
    }
}