using Microsoft.EntityFrameworkCore;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;
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
        DbSet<UserGroup> UsersGroups { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
