using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Models.ViewModels.Executor;

public class CreateExecutorViewModel
{
    
    public List<Models.User> Users { get; set; }
    [Required]
    public List<Guid> UserId { get; set; }
    public int Code { get; set; }
    public DateTime DateOfOrder { get; set; }
    [Required]
    public Guid DocumentId { get; set; }
    [Required]
    public string ExecutionTime { get; set; }
    [Required]
    public string Description { get; set; }
}