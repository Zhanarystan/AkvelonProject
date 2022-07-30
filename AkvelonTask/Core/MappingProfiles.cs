using AkvelonTask.DTOs;
using AkvelonTask.Models;

namespace AkvelonTask.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProjectDto, Project>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CompletionDate, o => o.MapFrom(s => s.CompletionDate))
                .ForMember(d => d.Priority, o => o.MapFrom(s => s.Priority));
            
            CreateMap<CreateTaskDto, AppTask>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Priority, o => o.MapFrom(s => s.Priority))
                .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId));
        }
    }
}