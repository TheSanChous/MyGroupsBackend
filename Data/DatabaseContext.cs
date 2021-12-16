using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
