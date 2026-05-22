using Asp.Versioning;
using Upnext.Postgres;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.InstallPostgresAdapter();

// Application
builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});

// Http
builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc();

builder.Services.AddControllers();

var app = builder.Build();

// If development -> apply pending migrations
if (app.Environment.IsDevelopment())
{
    var scope = app.Services.CreateScope();
    scope.MigrateDatabase();
}

app.MapControllers();

app.Run();