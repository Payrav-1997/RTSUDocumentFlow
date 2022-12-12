namespace DocumentFlow.Models;

public class Executor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Code { get; set; }
    public DateTime? DateOfOrder { get; set; }
    public Guid DocumentId { get; set; }
    public string ExecutionTime { get; set; }
    public string Description { get; set; }
    public string ExecutorRole { get; set; }
    public DateTime CreatedAt { get; set; }
    public int StatusId { get; set; }

    public virtual User User { get; set; }
    public virtual Document Document { get; set; }
    public virtual Status Status { get; set; }
}