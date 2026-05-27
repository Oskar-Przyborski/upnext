using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Upnext.Application.Output;
using Upnext.Postgres.Queries;
using Upnext.Postgres.Repositories;

namespace Upnext.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection InstallPostgresAdapter(this IServiceCollection services)
    {
        services.AddDbContext<IUnitOfWork, AppDbContext>();
        services.AddScoped<ITodoItemRepository, DbTodoItemRepository>();
        services.AddScoped<ITodoItemQuery, DbTodoItemQuery>();
        services.AddScoped<ITodoItemsQuery, DbTodoItemsQuery>();

        return services;
    }

    public static IServiceScope MigrateDatabase(this IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var migrations = dbContext.Database.GetPendingMigrations();
        if (migrations.Any()) dbContext.Database.Migrate();

        return scope;
    }
}