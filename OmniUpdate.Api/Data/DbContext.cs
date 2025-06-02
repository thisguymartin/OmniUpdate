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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Event>().ToTable("events");
        modelBuilder.Entity<EventIntegration>().ToTable("eventintegrations");
        modelBuilder.Entity<Integration>().ToTable("integrations");
        modelBuilder.Entity<UserIntegration>().ToTable("userintegrations");
        // ...add more if needed
    }
}