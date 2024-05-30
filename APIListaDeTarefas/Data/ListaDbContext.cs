using APIListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIListaDeTarefas.Data
{
    public class ListaDbContext : DbContext
    {
        public ListaDbContext(DbContextOptions<ListaDbContext> options) :base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
