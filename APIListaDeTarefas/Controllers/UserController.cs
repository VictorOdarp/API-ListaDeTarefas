using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> GetUserById(int id)
        {
            var user = await _userInterface.GetUserById(id);
            return Ok(user);
        }
    }
}
