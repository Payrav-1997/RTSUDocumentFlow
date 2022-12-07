namespace DocumentFlow.Models.ViewModels.Department;

public class GetDepartmentUsersDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Guid AdminId { get; set; }
}