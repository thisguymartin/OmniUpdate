using Microsoft.EntityFrameworkCore;
using OmniUpdate.Api.Data;
using OmniUpdate.Api.Endpoints;
using OmniUpdate.Api.Repositories;
using OmniUpdate.Api.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<DapperContext>();

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDBContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("Default")));


var app = builder.Build();

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

