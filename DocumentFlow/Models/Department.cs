namespace DocumentFlow.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<User> Users { get; set; }
}