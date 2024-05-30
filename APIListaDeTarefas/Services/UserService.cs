using APIListaDeTarefas.Data;
using APIListaDeTarefas.Dto.User;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Services
{
    public class UserService : IUserInterface
    {
        private readonly ListaDbContext _context;

        public UserService(ListaDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<List<UserModel>>> ListUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UserModel>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UserModel>> GetUserByIdTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> CreateUser(UserCriacaoDto newTask)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> EditUser(UserEdicaoDto editTask)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
