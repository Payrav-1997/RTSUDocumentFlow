namespace DocumentFlow.Models.ViewModels.Executor;

public class CreateExecutorViewModel
{
    public List<Models.User> Users { get; set; }
    public int Code { get; set; }
    public DateTime DateOfOrder { get; set; }
    public Guid DocumentId { get; set; }
    public Guid UserId { get; set; }
  //  public DateTime ExecutionTime { get; set; }
    public string Description { get; set; }
    public string ExecutorRole { get; set; }
}