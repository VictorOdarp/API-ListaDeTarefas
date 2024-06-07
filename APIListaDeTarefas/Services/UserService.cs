using APIListaDeTarefas.Data;
using APIListaDeTarefas.Dto.User;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIListaDeTarefas.Services
{
    public class UserService : IUserInterface
    {
        private readonly ListaDbContext _context;

        public UserService(ListaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UserModel>>> ListUsers()
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();

            try
            {
                if (_context.Users.Count() == 0)
                {
                    responseModel.Data = null;
                    responseModel.Message = "No users found";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "Lista de usuário encontrados!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<UserModel>> GetUserById(int id)
        {
            ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

            try
            {
                UserModel user = await _context.Users.Include(Task => Task.Tasks).FirstOrDefaultAsync(userData  => userData.Id == id); 

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Nonexistent user";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = user;
                responseModel.Message = "User found!";
                return responseModel; 
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<UserModel>> GetUserByIdTask(int idTask)
        {
            ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

            try
            {
                TaskModel task = await _context.Tasks.Include(U => U.User).FirstOrDefaultAsync(bancoTask => bancoTask.Id == idTask);

                if (task == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Task not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = task.User;
                responseModel.Message = "User found based on tasks!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }

            
        }

        public async Task<ResponseModel<List<UserModel>>> CreateUser(UserCriacaoDto newUser)
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();

            try
            {
                UserModel user = new UserModel()
                {
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                };

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Report data!";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Add(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User created successfully!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> EditUser(UserEdicaoDto editUser)
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();

            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUsers => bancoUsers.Id == editUser.Id); 

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Data not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                user.Id = editUser.Id;
                user.Name = editUser.Name;
                user.Surname = editUser.Surname;

                _context.Update(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User edited successfully!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> DeleteUser(int id)
        {
            ResponseModel<List<UserModel>> responseModel = new ResponseModel<List<UserModel>>();

            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUsers => bancoUsers.Id == id); 

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Data not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(user);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Users.ToListAsync();
                responseModel.Message = "User removed successfully";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }
    }
}
