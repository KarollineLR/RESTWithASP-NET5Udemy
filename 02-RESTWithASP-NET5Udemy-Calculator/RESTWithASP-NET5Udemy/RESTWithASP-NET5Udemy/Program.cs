using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET5Udemy.Business;
using RESTWithASP_NET5Udemy.Business.Implementations;
using RESTWithASP_NET5Udemy.Model.Context;
using RESTWithASP_NET5Udemy.Repository;
using RESTWithASP_NET5Udemy.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
