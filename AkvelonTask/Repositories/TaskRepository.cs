using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonTask.Data;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTask.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateTask(AppTask task)
        {
            _context.Tasks.Add(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTask(AppTask task)
        {
            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsTask(Guid id)
        {
            return await _context.Tasks.AnyAsync(t => t.Id == id);
        }

        public async Task<AppTask> GetTask(Guid id)
        {
            return await _context.Tasks.Where(t => t.Id == id)
                .Include(t => t.Project).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AppTask>> GetTasks(Guid projectId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<bool> DeleteTasks(IEnumerable<AppTask> tasks)
        {
            _context.Tasks.RemoveRange(tasks);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTask(AppTask task)
        {
            _context.Tasks.Update(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}