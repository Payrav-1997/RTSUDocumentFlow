namespace DocumentFlow.Models;

public class Users
{
    public Guid Id { get; set; }
    public Guid? DepartmentId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Logo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid RolesId { get; set; }
    public virtual Roles Roles { get; set; }
    public virtual Department? Department { get; set; }
}