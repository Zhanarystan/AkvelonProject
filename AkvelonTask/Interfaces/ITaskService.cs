using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Core;
using AkvelonTask.DTOs;
using AkvelonTask.Models;

namespace AkvelonTask.Interfaces
{
    public interface ITaskService
    {
        Task<Result<IEnumerable<AppTask>>> GetTasks(Guid projectId);
        Task<Result<AppTask>> GetTask(Guid id);
        Task<Result<AppTask>> CreateTask(CreateTaskDto dto);
        Task<Result<AppTask>> UpdateTask(AppTask task);
        Task<Result<AppTask>> DeleteTask(Guid id);
    }
}