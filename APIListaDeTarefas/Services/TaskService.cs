using APIListaDeTarefas.Data;
using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace APIListaDeTarefas.Services
{
    public class TaskService : ITaskInterface
    {
        private readonly ListaDbContext _context;
        public TaskService(ListaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TaskModel>>> ListTasks()
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            {
                if (_context.Tasks.Count() ==  0)
                {
                    responseModel.Data = null;
                    responseModel.Message = "No data found";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = await _context.Tasks.Include(user => user.User).ToListAsync();
                responseModel.Message = "Task list found!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<TaskModel>> GetTaskById(int id)
        {
            ResponseModel<TaskModel> responseModel = new ResponseModel<TaskModel>();

            try
            {
                TaskModel task = await _context.Tasks.Include(user => user.User).FirstOrDefaultAsync(x => x.Id == id); 

                if (task == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "No task found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = task;
                responseModel.Message = "Task found!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        } 

        public async Task<ResponseModel<List<TaskModel>>> GetTaskByIdUser(int idUser)
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            {
                var task = await _context.Tasks.Include(user => user.User).Where(bancoTasks => bancoTasks.User.Id == idUser).ToListAsync();

                if (task == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Id User not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = task;
                responseModel.Message = "Tasks found by User";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> CreateTask(TaskCriacaoDto newTask)
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            { 

                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUsers => bancoUsers.Id == newTask.User.Id);

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "User not found";
                    responseModel.Status = false;
                    return responseModel;
                }

                TaskModel task = new TaskModel()
                {
                    Title = newTask.Title,
                    Description = newTask.Description,
                    User = user,
                };

                _context.Add(task);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Tasks.Include(user => user.User).ToListAsync();
                responseModel.Message = "Task created successfully";
                return responseModel;

            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> EditTask(TaskEdicaoDto editTask)
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            {
                TaskModel task = await _context.Tasks.FirstOrDefaultAsync(bancoTasks => bancoTasks.Id == editTask.Id);

                if (task == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Task not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                UserModel user = await _context.Users.FirstOrDefaultAsync(bancoUser => bancoUser.Id == editTask.User.Id);

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "User not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                task.Title = editTask.Title;
                task.Description = editTask.Description;
                task.User = user;

                _context.Update(task);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Tasks.Include(user => user.User).ToListAsync();
                responseModel.Message = "Task edited sucessfully!";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> DeleteTask(int idTask)
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            {
                TaskModel task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == idTask);

                if (task == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Data not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(task);
                await _context.SaveChangesAsync();

                responseModel.Data = await _context.Tasks.Include(user => user.User).ToListAsync();
                responseModel.Message = "Task removed sucessfully";
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
