using Microsoft.EntityFrameworkCore;

namespace DocumentFlow.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Executor> Executors { get; set; }
    public DbSet<Notion> Notions { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Role>().HasData(
            new Role()
            {
                Id = 1,
                Name = "Админ"
            },
            new Role()
            {
                Id = 2,
                Name = "Сотрудник"
            },
            new Role()
            {
                Id = 3,
                Name = "Исполниель"
            }
        );
        model.Entity<Status>().HasData(
            new Status()
            {
                Id = 1,
                Name = "Новый"
            },
            new Status()
            {
                Id = 2,
                Name = "В процессе"
            },
            new Status()
            {
                Id = 3,
                Name = "Отказано"
            },
            new Status()
            {
                Id = 4,
                Name = "Одобрено"
            }
        );
        model.Entity<Department>().HasData(
            new Department()
            {
                Id = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                Name = "Алиф",
                CreatedAt = DateTime.UtcNow
            }
        );
        model.Entity<User>().HasData(
            new User()
            {
                Id = Guid.NewGuid(),
                Name = "Админ",
                Address = "Test",
                Email = "Admin@gmail.com",
                Logo = "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                RoleId = 1,
                Phone = "+992915224442",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440")
            }
        );
     
    }
}