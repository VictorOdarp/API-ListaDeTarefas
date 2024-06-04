using APIListaDeTarefas.Data;
using APIListaDeTarefas.Interfaces;
using APIListaDeTarefas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<ITaskInterface, TaskService>();

var DefaultConnection = "server=localhost;userid=root;password=895smigol;database=LivroAutor;";

builder.Services.AddDbContext<ListaDbContext>(options =>
{
    options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
