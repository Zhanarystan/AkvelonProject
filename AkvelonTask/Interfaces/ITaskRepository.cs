using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Models;

namespace AkvelonTask.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<AppTask>> GetTasks(Guid projectId);
        Task<AppTask> GetTask(Guid id);
        Task<bool> CreateTask(AppTask task);
        Task<bool> UpdateTask(AppTask task);
        Task<bool> DeleteTask(AppTask task);
        Task<bool> ExistsTask(Guid id);
        Task<bool> DeleteTasks(IEnumerable<AppTask> tasks);
    }
}