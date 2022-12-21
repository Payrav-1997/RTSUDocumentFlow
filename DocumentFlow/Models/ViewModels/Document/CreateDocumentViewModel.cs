namespace DocumentFlow.Models.ViewModels.Document;

public class CreateDocumentViewModel
{
    public string Type { get; set; }
    public string Topic { get; set; }
    public string Correspondent { get; set; }
    public string CorrespondentNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public List<Models.Department> Departments { get; set; }
}