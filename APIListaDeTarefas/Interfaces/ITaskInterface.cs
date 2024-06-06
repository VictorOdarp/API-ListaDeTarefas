using APIListaDeTarefas.Dto.Task;
using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Interfaces
{
    public interface ITaskInterface
    {
        public Task<ResponseModel<List<TaskModel>>> ListTasks();
        public Task<ResponseModel<TaskModel>> GetTaskById(int id);
        public Task<ResponseModel<List<TaskModel>>> GetTaskByIdUser(int idUser);
        public Task<ResponseModel<List<TaskModel>>> CreateTask (TaskCriacaoDto newTask);
        public Task<ResponseModel<List<TaskModel>>> EditTask (TaskEdicaoDto editTask);
        public Task<ResponseModel<List<TaskModel>>> DeleteTask (int idTask);
     }
}
