using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Dto.User;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace APIListaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("ListUsers")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListUsers()
        {
            var list = await _userInterface.ListUsers();
            return Ok(list);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<ResponseModel<UserModel>>> GetUserById(int id)
        {
            var user = await _userInterface.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("GetUserByIdTask")]
        public async Task<ActionResult<ResponseModel<UserModel>>> GetUserByIdTask(int idTask)
        {
            var task = await _userInterface.GetUserByIdTask(idTask);
            return Ok(task);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser (UserCriacaoDto userCriacaoDto)
        {
            var user = await _userInterface.CreateUser(userCriacaoDto);
            return Ok(user);
        }

        [HttpPut("EditUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> EditUser(UserEdicaoDto userEdicaoDto)
        {
            var user = await _userInterface.EditUser(userEdicaoDto);
            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser (int id)
        {
            var user = await _userInterface.DeleteUser(id);
            return Ok(user);
        }
    }
}
