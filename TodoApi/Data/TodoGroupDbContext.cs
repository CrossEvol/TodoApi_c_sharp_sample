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
        modelBuilder.Entity<Todo>().Property(e => e.Priority).HasConversion<string>();
        modelBuilder.Entity<Todo>().Property(t => t.CreateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<Todo>().Property(t => t.UpdateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateTimeStamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimeStamps()
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateTime").CurrentValue = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdateTime").CurrentValue = DateTime.Now;
            }
        }
    }
}
