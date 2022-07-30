using System;

namespace AkvelonTask.Models
{
    public class AppTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}