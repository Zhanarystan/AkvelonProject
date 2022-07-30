using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.Core;
using AkvelonTask.DTOs;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AkvelonTask.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IList<string> _modelErrors;
        public ProjectService
        (
            IProjectRepository projectRepository, 
            ITaskRepository taskRepository, 
            IMapper mapper
        )
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
            _modelErrors = new List<string>();
        }
        public async Task<Result<Project>> CreateProject(CreateProjectDto dto)
        {
            var project = new Project();
            _mapper.Map(dto, project);
            project.StartDate = DateTime.Now;
            project.Status = ProjectStatus.NotStarted;

            if(!ValidateProject(project)) return Result<Project>.Failure(_modelErrors);

            var isSuccess = await _projectRepository.CreateProject(project);

            if(!isSuccess) return Result<Project>.Failure(null);
            
            return Result<Project>.Success(project);
        }

        public async Task<Result<Project>> DeleteProject(Guid id)
        {
            var project = await _projectRepository.GetProject(id);

            if(project == null) return null;

            var tasks = await _taskRepository.GetTasks(id) as List<AppTask>;

            if(tasks.Count > 0 && !await _taskRepository.DeleteTasks(tasks))
                return Result<Project>.Failure(null);

            var isSuccess = await _projectRepository.DeleteProject(project);
            
            if(!isSuccess) return Result<Project>.Failure(null);
            
            return Result<Project>.Success(project);
        }

        public async Task<Result<Project>> GetProject(Guid id)
        {
            return Result<Project>.Success(await _projectRepository.GetProject(id));
        }

        public async Task<Result<IEnumerable<Project>>> GetProjects()
        {
            return Result<IEnumerable<Project>>.Success(await _projectRepository.GetProjects());
        }

        public async Task<Result<Project>> UpdateProject(Project updatedProject)
        {            
            if(!await _projectRepository.ExistsProject(updatedProject.Id)) return null;
            
            if(!ValidateProject(updatedProject)) return Result<Project>.Failure(_modelErrors);

            var isSuccess = await _projectRepository.UpdateProject(updatedProject);

            if(!isSuccess) return Result<Project>.Failure(null);

            return Result<Project>.Success(updatedProject);
        }

        public async Task<Result<IEnumerable<AppTask>>> GetTasks(Guid id)
        {
            return Result<IEnumerable<AppTask>>.Success(await _taskRepository.GetTasks(id));
        }

        //Model validation method
        private bool ValidateProject(Project project)
        {
            if(project.Name.Trim().Length == 0)
                _modelErrors.Add("Name is required.");
            if(project.Status < ProjectStatus.NotStarted || project.Status > ProjectStatus.Completed)
                _modelErrors.Add("Such status doesn't exist.");
            return _modelErrors.Count == 0;
        }
    }
} 