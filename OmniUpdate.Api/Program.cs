using Dapper;
using GameStore.Api.Repositories;
using OmniUpdate.Api.Data;
using OmniUpdate.Api.Endpoints;
using OmniUpdate.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserRepository, UserDbRepository>();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataAccess, DataAccess>();

var app = builder.Build();

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("DatabaseConnection");

builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //  http://localhost:5206/swagger/index.html
  app.UseSwagger();
  app.UseSwaggerUI();
  Console.WriteLine("Swagger: http://localhost:5206/swagger/index.html");

}

app.UseHttpsRedirection();

app.MapUserEndpoints();
app.Run();

