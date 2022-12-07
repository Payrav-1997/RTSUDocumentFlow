namespace DocumentFlow.Models;

public class Executor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Code { get; set; }
    public DateTime Type { get; set; }
}