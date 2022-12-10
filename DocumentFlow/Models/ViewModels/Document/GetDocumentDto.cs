namespace DocumentFlow.Models.ViewModels.Document;

public class GetDocumentDto
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public int DocumentNumber { get; set; }
    public string Type { get; set; }
    public string Topic { get; set; }
    public string Correspondent { get; set; }
    public string CorrespondentNumber { get; set; }
    public DateTime CreatedAtCorrespondent { get; set; }
}