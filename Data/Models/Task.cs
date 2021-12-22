using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Task : ModelBase
    {
        public Group Group { get; set; }
        public User Customer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LoadedAt { get; set; }
        public DateTime Deadline { get; set; }
        public File File { get; set; }
    }
}