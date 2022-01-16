using Microsoft.EntityFrameworkCore;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Tasks;
using MyGroups.Domain.Models.Users;
using MyGroups.Domain.Models.Grades;
using MyGroups.Domain.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Domain.Models.Tasks.Task> Tasks { get; set; }
        DbSet<Domain.Models.Tasks.CompletedTask> CompletedTasks { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<UserGroup> UsersGroups { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
