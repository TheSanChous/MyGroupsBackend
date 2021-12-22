using System;

namespace Data.Models
{
    public class Grade : ModelBase
    {
        public CompletedTask ComplatedTask { get; set; }
        public Guid ComplatedTaskId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}