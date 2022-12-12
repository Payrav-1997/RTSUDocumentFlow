namespace DocumentFlow.Models.ViewModels.Document;

public class GetAllDocumentsViewModel
{
    public string Type { get; set; }
    public Guid Id { get; set; }
    public string Correspondent { get; set; }
    public int DocumentNumber { get; set; }
    public string Topic { get; set; }
    public string Status { get; set; }
}