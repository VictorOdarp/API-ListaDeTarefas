using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Dto.Task
{
    public class TaskEdicaoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserModel User { get; set; }
    }
}
