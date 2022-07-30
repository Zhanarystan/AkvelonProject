using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Core;
using AkvelonTask.DTOs;
using AkvelonTask.Models;

namespace AkvelonTask.Interfaces
{
    public interface IProjectService
    {
        Task<Result<IEnumerable<Project>>> GetProjects();
        Task<Result<Project>> GetProject(Guid id);
        Task<Result<Project>> CreateProject(CreateProjectDto dto);
        Task<Result<Project>> DeleteProject(Guid id);
        Task<Result<Project>> UpdateProject(Project project);
        Task<Result<IEnumerable<AppTask>>> GetTasks(Guid id);
    }
}