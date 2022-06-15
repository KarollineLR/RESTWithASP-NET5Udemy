using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET5Udemy.Business;
using RESTWithASP_NET5Udemy.Business.Implementations;
using RESTWithASP_NET5Udemy.Model.Context;
using RESTWithASP_NET5Udemy.Repository;
using RESTWithASP_NET5Udemy.Repository.Implementations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("MySQL");

var configuration = builder.Configuration;

var Environment = builder.Environment;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddControllers();

builder.Services.AddApiVersioning();

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

if (Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

void MigrateDatabase(string connection)
{
    try
    {
        var EvolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
        var evolve = new EvolveDb.Evolve(EvolveConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
