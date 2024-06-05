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

        public async Task<ResponseModel<List<TaskModel>>> GetTaskByIdUser(int id)
        {
            ResponseModel<List<TaskModel>> responseModel = new ResponseModel<List<TaskModel>>();

            try
            {
                UserModel user = await _context.Users.Include(task => task.Tasks).FirstOrDefaultAsync(x => x.Id == id); 

                if (user == null)
                {
                    responseModel.Data = null;
                    responseModel.Message = "Id User not found!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Data = user.Tasks.ToList();
                responseModel.Message = "Tasks found by Autor";
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public Task<ResponseModel<List<TaskModel>>> CreateTask(TaskCriacaoDto newTask)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TaskModel>>> EditTask(TaskEdicaoDto editTask)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TaskModel>>> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
