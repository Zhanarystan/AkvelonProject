using System;

namespace AkvelonTask.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public DateTime CompletionDate { get; set;}
        public int Priority { get; set; }
    }
}