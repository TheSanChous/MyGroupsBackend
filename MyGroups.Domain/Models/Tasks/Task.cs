using System;
using MyGroups.Domain.Models.Files;
using MyGroups.Domain.Models.Groups;
using MyGroups.Domain.Models.Users;

namespace MyGroups.Domain.Models.Tasks
{
    public class Task : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime Deadline { get; set; }
        public Group Group { get; set; }
        public User Creator { get; set; }
        public File File { get; set; }
    }
}