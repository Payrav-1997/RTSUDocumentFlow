using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Document;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class DocumentController : BaseController
{
    private readonly DataContext _dataContext;

    public DocumentController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDocumentViewModel documentViewModel)
    {
        var userId = GetCurrentUserId();
        var document = new Document()
        {
            Id = Guid.NewGuid(),
            Topic = documentViewModel.Topic,
            Type = documentViewModel.Type,
            CorrespondentNumber = documentViewModel.CorrespondentNumber,
            Correspondent = documentViewModel.Correspondent,
            CreatedAtCorrespondent = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            StatusId = 1,
            DocumentNumber = NumberGenerator(6),
            UserId = userId
        };
        await _dataContext.AddAsync(document);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetById","Document");
    }
    
    private static int NumberGenerator(int i)
    {
        if (i < 2)
        {
            throw new Exception("digitsCount must be greater than or equal to 2");
        }
        var min = Math.Pow(10, i - 1);
        var max = Math.Pow(10, i) - 1;
        var random = new Random();
        return random.Next((int)min, (int)max);
    }


    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var document = await _dataContext.Documents.FindAsync(id);
        if (document == null)
        {
            ModelState.AddModelError("", "Документ не найден!");
            return View(new GetDocumentDto());
        }
        var newDocument = new GetDocumentDto()
        {
            Id = document.Id,
            Correspondent = document.Correspondent,
            Status = document.Status.Name,
            Topic = document.Topic,
            Type = document.Type,
            CorrespondentNumber = document.CorrespondentNumber,
            DocumentNumber = document.DocumentNumber,
            CreatedAtCorrespondent = document.CreatedAtCorrespondent
        };
        return View(newDocument);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetCurrentUserId();
        var doc = _dataContext.Documents.Where(x => x.UserId.Equals(userId)).Select(x => new GetAllDocumentsViewModel()
        {
            Id = x.Id,
            Type = x.Type
        }).ToList();
        return View(doc);
    }
}