namespace DocumentFlow.Models.ViewModels.Department;

public class GetDepartmentViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserRole { get; set; }
    public Guid UserId { get; set; }
}