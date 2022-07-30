using System;

namespace AkvelonTask.DTOs
{
    public class CreateTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Guid ProjectId { get; set; }
    }
}