using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CompletedTask> CompletedTasks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<RoleUserInGroup> RoleUserInGroups { get; set; }
        public DbSet<Schelude> Scheludes { get; set; }
        public DbSet<ScheludeItem> ScheludeItems { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
