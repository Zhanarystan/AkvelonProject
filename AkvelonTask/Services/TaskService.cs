using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Core;
using AkvelonTask.DTOs;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using AutoMapper;

namespace AkvelonTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IList<string> _modelErrors;
        public TaskService
        (
            ITaskRepository taskRepository, 
            IMapper mapper
        )
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _modelErrors = new List<string>();
        }
        public async Task<Result<AppTask>> CreateTask(CreateTaskDto dto)
        {
            var task = new AppTask();
            _mapper.Map(dto, task);

            if(!ValidateTask(task)) return Result<AppTask>.Failure(_modelErrors);
            
            var isSuccess = await _taskRepository.CreateTask(task);

            if(!isSuccess) return Result<AppTask>.Failure(null);

            return Result<AppTask>.Success(task);
        }

        public async Task<Result<AppTask>> DeleteTask(Guid id)
        {
            var task = await _taskRepository.GetTask(id);
            if(task == null)
                return null;

            var isSuccess = await _taskRepository.DeleteTask(task);

            if(!isSuccess) 
                return Result<AppTask>.Failure(null);
            return Result<AppTask>.Success(task);
        }

        public async Task<Result<AppTask>> GetTask(Guid id)
        {
            return Result<AppTask>.Success(await _taskRepository.GetTask(id));
        }

        public async Task<Result<IEnumerable<AppTask>>> GetTasks(Guid projectId)
        {
            return Result<IEnumerable<AppTask>>.Success(await _taskRepository.GetTasks(projectId));
        }

        public async Task<Result<AppTask>> UpdateTask(AppTask updatedTask)
        {
            if(!await _taskRepository.ExistsTask(updatedTask.Id)) return null;

            var isSuccess = await _taskRepository.UpdateTask(updatedTask);
            
            if(!ValidateTask(updatedTask)) return Result<AppTask>.Failure(_modelErrors);

            if(!isSuccess) return Result<AppTask>.Failure(null);
            return Result<AppTask>.Success(updatedTask);
        }

        private bool ValidateTask(AppTask task)
        {
            if(task.Name.Trim().Length == 0)
                _modelErrors.Add("Name is required.");
            if(task.Description.Trim().Length == 0)
                _modelErrors.Add("Description is required.");
            if(task.Status < Models.TaskStatus.ToDo || task.Status > Models.TaskStatus.Done)
                _modelErrors.Add("Such status doesn't exist.");
            return _modelErrors.Count == 0;
        }
    }
}