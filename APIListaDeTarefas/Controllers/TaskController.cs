using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIListaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskInterface _taskInterface;

        public TaskController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpGet("ListTasks")]
        
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> ListTasks()
        {
            var tasks = await _taskInterface.ListTasks();
            return Ok(tasks);
        }

        [HttpGet("GetTaskById")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> GetTaskById (int id)
        {
            var task = await _taskInterface.GetTaskById(id);
            return Ok(task);
        }

        [HttpGet("GetTaskByIdUser")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> GetTaskByIdUser (int idUser)
        {
            var task = await _taskInterface.GetTaskByIdUser(idUser);
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> CreateTask (TaskCriacaoDto taskCriacaoDto)
        {
            var task = await _taskInterface.CreateTask(taskCriacaoDto);
            return Ok(task);
        }

        [HttpPut("EditTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> EditTask (TaskEdicaoDto taskEdicaoDto)
        {
            var task = await _taskInterface.EditTask(taskEdicaoDto);
            return Ok(task);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> DeleteTask (int id)
        {
            var task = await _taskInterface.DeleteTask(id);
            return Ok(task);
        }


    }
}
