using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Data;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    options.UseSqlite($"Data Source={Path.Join(path, "todo.db")}");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<TodoGroupDbContext>();
db?.Database.MigrateAsync();

// todoV1 endpoints
app.MapGroup("/todos/v1")
    .MapTodosApiV1()
    .WithTags("Todo Endpoints");

// todoV2 endpoints
app.MapGroup("/todos/v2")
    .MapTodosApiV2()
    .WithTags("Todo Endpoints");

app.Run();

public partial class Program
{ }
