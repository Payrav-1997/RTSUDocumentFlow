namespace DocumentFlow.Models;

public class Agreement
{
    public Guid Id { get; set; }
    public Guid ExecutorId { get; set; }
    public Guid DocumentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime AgreementDate { get; set; }
    public string Descrioption { get; set; }

    public virtual Executor Executor { get; set; }
    public virtual Document Document { get; set; }
}