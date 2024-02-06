using Microsoft.EntityFrameworkCore;
using OmniUpdate.Api.Models.Entities;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    // generate sets based on the entities in the Models/Entities folder
    public DbSet<Event> Event { get; set; }
    public DbSet<EventIntegration> EventIntegration { get; set; }

    public DbSet<Integration> Integration { get; set; }

    public DbSet<UserIntegration> UserIntegration { get; set; }




}