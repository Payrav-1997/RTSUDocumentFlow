namespace DocumentFlow.Models;

public class Notion
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
}