namespace DocumentFlow.Models.ViewModels.User;

public class CreateUserViewModel
{
    public string Name { get; set; }
    public string Password { get; set; }
    public IFormFile Logo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Guid RoleId { get; set; }
    public Guid DepartmentId { get; set; }

    public List<Roles> Roles{ get; set; }
    public List<Models.Department> Departments { get; set; }
}