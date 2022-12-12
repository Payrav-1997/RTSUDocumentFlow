namespace DocumentFlow.Models;

public class Notion
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DocumentId { get; set; }
    public string Message { get; set; }
}