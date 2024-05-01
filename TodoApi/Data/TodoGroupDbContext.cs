using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data;

public class TodoGroupDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();


    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable("todo");
        modelBuilder.Entity<Todo>().Property(e => e.priority).HasConversion<string>();
        base.OnModelCreating(modelBuilder);
    }
}
