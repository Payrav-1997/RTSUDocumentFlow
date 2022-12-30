namespace DocumentFlow.Models.ViewModels.User;

public class CreateUserViewModel
{
    public string Name { get; set; }
    public string Password { get; set; }
  //  public IFormFile Logo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public int RoleId { get; set; } = 2;
    public Guid DepartmentId { get; set; } = new Guid("e7bf76fc-035a-4e5c-81ae-6492421107be");

    public List<Role> Roles{ get; set; }
    public List<Models.Department> Departments { get; set; }
}