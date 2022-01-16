using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Files;
using MyGroups.Domain.Models.Grades;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
using System.Reflection;

namespace MyGroups.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Domain.Models.Tasks.Task> Tasks { get; set; }
        public DbSet<Domain.Models.Tasks.CompletedTask> CompletedTasks { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<UserGroup> UsersGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
