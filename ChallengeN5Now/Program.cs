using ChallengeN5Now.Business;
using ChallengeN5Now.Data;
using ChallengeN5Now.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDataServices(builder.Configuration)
    .AddBusinessServices()
    .AddDomainServices(builder.Configuration);

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

builder.Services.AddSingleton(Log.Logger);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("sql_server") ?? throw new InvalidOperationException("Connection string 'sql_server' not found.");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var applicationDbContext = services.GetRequiredService<AppDbContext>();
    applicationDbContext.Database.EnsureCreated();

    //if (applicationDbContext.Database.GetPendingMigrations().Any())
    //{
    //    applicationDbContext.Database.Migrate();
    //}
}


app.Run();

public partial class Program { }