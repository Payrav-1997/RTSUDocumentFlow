namespace DocumentFlow.Models;

public class Document
{
    public Guid Id { get; set; }
    public int DocumentNumber { get; set; }
    public string Type { get; set; }
    public string Topic { get; set; }
    public string Correspondent { get; set; }
    public string CorrespondentNumber { get; set; }
    public DateTime CreatedAtCorrespondent { get; set; }
    
    
    
}