using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RESTWithASP_NET5Udemy.Business;
using RESTWithASP_NET5Udemy.Business.Implementations;
using RESTWithASP_NET5Udemy.Configurations;
using RESTWithASP_NET5Udemy.Hypermedia.Envicher;
using RESTWithASP_NET5Udemy.Hypermedia.Filters;
using RESTWithASP_NET5Udemy.Model.Context;
using RESTWithASP_NET5Udemy.Repository;
using RESTWithASP_NET5Udemy.Repository.Generic;
using RESTWithASP_NET5Udemy.Services;
using RESTWithASP_NET5Udemy.Services.Implementations;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("MySQL");

var configuration = builder.Configuration;

var Environment = builder.Environment;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddControllers();

var tokenConfigurations = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(
    configuration.GetSection("TokenConfigurations")
)
    .Configure(tokenConfigurations);
builder.Services.AddSingleton(tokenConfigurations);

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenConfigurations.Issuer,
            ValidAudience = tokenConfigurations.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
        };
    });

builder.Services.AddAuthorization(auth =>
    {
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser().Build());
});

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "REST API's From0 to Azure with APS.NET Core 5 and Docker",
            Version = "v1",
            Description = "API RESTFul developed in course",
            Contact = new OpenApiContact
            {
               Name = "Karolline",
               Url = new Uri("https://www.google.com.br")
            }
        });

});

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

//if (Environment.IsDevelopment())
//{
//    MigrateDatabase(connection);
//}
builder.Services.AddMvc().AddXmlDataContractSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentRespponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentRespponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

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

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();

builder.Services.AddScoped<IFileBusiness, FileBusinessImplementation>();

builder.Services.AddTransient<ITokenServices, TokenServices>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "REST API's From0 to Azure with APS.NET Core 5 and Docker");
});

var option = new RewriteOptions();

app.UseRewriter(option);

option.AddRedirect("^$", "swagger");

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("DefaultApi", "{controller=value}/{id?}");

app.Run();
