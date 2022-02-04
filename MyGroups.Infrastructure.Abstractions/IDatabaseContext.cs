using Microsoft.EntityFrameworkCore;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Tasks;
using MyGroups.Domain.Models.Users;
using MyGroups.Domain.Models.Grades;
using MyGroups.Domain.Models.Files;
using System.Threading;
using System.Threading.Tasks;
using GroupTask = MyGroups.Domain.Models.Tasks.Task;

namespace MyGroups.Infrastructure.Abstractions
{
    public interface IDatabaseContext
    {
        DbSet<GroupTask> Tasks { get; set; }
        DbSet<CompletedTask> CompletedTasks { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<UserGroup> UsersGroups { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
