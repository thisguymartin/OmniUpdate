using GameStore.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using OmniUpdate.Api.Data;
using OmniUpdate.Api.Dtos;
using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "/user")]
        public async IEnumerable<User> GetAllUsers(IUserService userService) 
        {
            var users = await userService.GetAll();
            return users;
        }

        // [HttpGet(Name = "/user/{id}")]
        // public WeatherForecast GetUser(int id)
        // {

        //     return Results.NoContent();
        // }



        // [HttpGet(Name = "/user")]
        // public WeatherForecast GetUser(UserDto userdto)
        // {
        //     var d = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55),
        //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //     })
        //     .ToArray();

        //     return Results.Ok<WeatherForecast>(d);
        // }
    }
}