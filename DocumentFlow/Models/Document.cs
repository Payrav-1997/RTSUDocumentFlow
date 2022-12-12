namespace DocumentFlow.Models;

public class Document
{
    public Guid Id { get; set; }
    public int StatusId { get; set; }
    public int DocumentNumber { get; set; }
    public string Type { get; set; }
    public string Topic { get; set; }
    public string Correspondent { get; set; }
    public string CorrespondentNumber { get; set; }
    public DateTime CreatedAtCorrespondent { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual Status Status { get; set; }
    public Guid UserId { get; set; }
    
    
    
    public virtual ICollection<Agreement> Agreements { get; set; }
    public virtual ICollection<Executor> Executors { get; set; }
    
}