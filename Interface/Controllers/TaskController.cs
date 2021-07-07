using Common.DTO.Tasks;
using Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Tasks;

namespace Interface.Controllers
{
    [ApiController]   
    [Authorize]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        protected TaskService _taskService;

        public TaskController(TaskService tasksService)
        {
            _taskService = tasksService;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var username = HttpContext.User.Identity.Name;

            return Ok(_taskService.GetTasks(username));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_taskService.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateTask(TaskCreateDto taskCreateDto)
        {
            var username = HttpContext.User.Identity.Name;

            return Ok(_taskService.CreateTask(taskCreateDto, username));
        }

        [HttpPatch]
        [Route("{id:int}/status/{status}")]
        public IActionResult UpdateStatus(int id, TaskStatusEnum status)
        {
            return Ok(_taskService.UpdateTask(id, status));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
        }
    }
}
