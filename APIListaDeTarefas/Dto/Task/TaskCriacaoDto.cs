using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Dto.Task
{
    public class TaskCriacaoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserModel User { get; set; }
    }
}
