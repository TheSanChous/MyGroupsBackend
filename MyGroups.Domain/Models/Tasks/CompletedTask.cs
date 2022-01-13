using MyGroups.Domain.Models.Files;
using MyGroups.Domain.Models.Grades;

namespace MyGroups.Domain.Models.Tasks
{
    public class CompletedTask : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Task Task { get; set; }
        public Grade Grade { get; set; }
        public File File { get; set; }
    }
}