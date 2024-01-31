using GameStore.Api.Repositories;
using OmniUpdate.Api.Endpoints;
using OmniUpdate.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserRepository, UserDbRepository>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

