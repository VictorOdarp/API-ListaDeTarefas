using APIListaDeTarefas.Data;
using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Services
{
    public class TaskService : ITaskInterface
    {
        private readonly ListaDbContext _context;
        public TaskService(ListaDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<List<TaskModel>>> ListTasks()
        {
            throw new NotImplementedException();
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
