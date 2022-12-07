using Microsoft.EntityFrameworkCore;

namespace DocumentFlow.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Roles>().HasData(
            new Roles()
            {
                Id = new Guid("c226e52f-223d-4ddc-810c-d4f6b345f350"),
                Name = "Админ"
            },
            new Roles()
            {
                Id = Guid.NewGuid(),
                Name = "Пользователь"
            }
        );
        
        model.Entity<Status>().HasData(
            new Status()
            {
                Id = Guid.NewGuid(),
                Name = "Новый"
            },
            new Status()
            {
                Id = Guid.NewGuid(),
                Name = "Одобренно"
            }
        );
        model.Entity<Department>().HasData(
            new Department()
            {
                Id = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                Name = "Test",
                CreatedAt = DateTime.UtcNow
            }
        );
        model.Entity<Users>().HasData(
            new Users()
            {
                Id = Guid.NewGuid(),
                Name = "Админ",
                Address = "Test",
                Email = "Admin@gmail.com",
                Logo = string.Empty,
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                RolesId = new Guid("c226e52f-223d-4ddc-810c-d4f6b345f350"),
                Phone = "+992915224442",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440")
            }
        );
     
    }
}