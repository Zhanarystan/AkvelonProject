using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Data;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTask.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Project> GetProject(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<bool> UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsProject(Guid id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }
    }
}