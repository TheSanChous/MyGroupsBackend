using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CompletedTask : ModelBase
    {
        public Task Task { get; set; }
        public User Performer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LoadedAt { get; set; }
        public File File { get; set; }
        public Grade Grade { get; set; }
    }
}
