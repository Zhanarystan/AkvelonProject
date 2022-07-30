using System;
using System.Threading.Tasks;
using AkvelonTask.DTOs;
using AkvelonTask.Interfaces;
using AkvelonTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkvelonTask.Controllers
{
    [AllowAnonymous]
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppTask>> GetTask(Guid id)
        {
            return HandleResult(await _taskService.GetTask(id));
        }

        [HttpPost]
        public async Task<ActionResult<AppTask>> CreateTask(CreateTaskDto dto)
        {
            return HandleResult(await _taskService.CreateTask(dto));
        }

        [HttpPut]
        public async Task<ActionResult<AppTask>> UpdateTask(AppTask task)
        {
            return HandleResult(await _taskService.UpdateTask(task));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppTask>> DeleteTask(Guid id)
        {
            return HandleResult(await _taskService.DeleteTask(id));
        }
    }
}