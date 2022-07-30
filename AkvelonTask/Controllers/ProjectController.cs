using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTask.DTOs;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkvelonTask.Controllers
{
    public class ProjectController : BaseApiController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return HandleResult(await _projectService.GetProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            return HandleResult(await _projectService.GetProject(id));
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(CreateProjectDto dto)
        {
            return HandleResult(await _projectService.CreateProject(dto));
        }

        [HttpPut]
        public async Task<ActionResult<Project>> UpdateProject(Project project)
        {
            return HandleResult(await _projectService.UpdateProject(project));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(Guid id)
        {
            return HandleResult(await _projectService.DeleteProject(id));
        }

        [HttpGet("{id}/tasks")]
        public async Task<ActionResult<IEnumerable<AppTask>>> GetTasks(Guid id)
        {
            return HandleResult(await _projectService.GetTasks(id));
        }
    }
}