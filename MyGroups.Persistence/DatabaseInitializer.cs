using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Persistence
{
    public class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
