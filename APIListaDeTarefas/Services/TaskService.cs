using APIListaDeTarefas.Data;
using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

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

                responseModel.Data = await _context.Tasks.ToListAsync();
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

        public Task<ResponseModel<TaskModel>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TaskModel>> GetTaskByIdUser(int id)
        {
            throw new NotImplementedException();
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
