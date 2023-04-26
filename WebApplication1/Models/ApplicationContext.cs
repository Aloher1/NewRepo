using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationContext : DbContext
{
    public DbSet<product> objects { get; set; } = null!;
    public DbSet<cartproduct> cart { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}

