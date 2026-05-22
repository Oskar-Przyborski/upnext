using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Upnext.Application.Output;
using Upnext.Domain;

namespace Upnext.Postgres;

public class AppDbContext(IConfiguration configuration) : DbContext, IUnitOfWork
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("Database") ?? throw new InvalidOperationException(),
            options => { options.EnableRetryOnFailure(); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from /Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}