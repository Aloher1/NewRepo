using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationContext : DbContext
{
    public DbSet<product> objects { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<product>().HasData(
                new product { id = 1, name = "name1", price = 100 },
                new product { id = 2, name = "name2", price = 200 },
                new product { id = 3, name = "name3", price = 300 }
        );
    }
}

