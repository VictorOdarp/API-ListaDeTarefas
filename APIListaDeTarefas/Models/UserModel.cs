using System.Text.Json.Serialization;

namespace APIListaDeTarefas.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();

    }
}
