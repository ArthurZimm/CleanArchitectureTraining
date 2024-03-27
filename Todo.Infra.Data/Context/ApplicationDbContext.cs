using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.Domain.Entities;
using Todo.Infra.Data.EntitiesConfiguration;

namespace Todo.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-D19QQ33;Persist Security Info=True;User ID=sa;Password=arthur;Encrypt=False")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public ApplicationDbContext()
    { }
}