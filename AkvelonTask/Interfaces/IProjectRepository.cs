using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Models;

namespace AkvelonTask.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(Guid id);
        Task<bool> CreateProject(Project project);
        Task<bool> DeleteProject(Project project);
        Task<bool> UpdateProject(Project project);
        Task<bool> ExistsProject(Guid id);
    }
}