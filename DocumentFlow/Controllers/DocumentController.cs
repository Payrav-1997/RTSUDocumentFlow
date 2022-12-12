using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Document;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        return RedirectToAction("GetAll","Document");
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
        var currentUserId = GetCurrentUserId();
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
            CreatedAtCorrespondent = document.CreatedAtCorrespondent,
            Executors = document.Executors.ToList(),
            CurrentUserId = currentUserId
        };
        return View(newDocument);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doc = await _dataContext.Documents.Select(x => new GetAllDocumentsViewModel()
        {
            Id = x.Id,
            Type = x.Type,
            Correspondent = x.Correspondent,
            DocumentNumber = x.DocumentNumber,
            Topic = x.Topic,
            Status = x.Status.Name
        }).ToListAsync();
        return View(doc);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int statusId, Guid id,Guid executorId)
    {
        var executor = await _dataContext.Executors.FindAsync(executorId);
        if (executor == null)
        {
            return null;
        }
        executor.StatusId = statusId;
        await _dataContext.SaveChangesAsync();
        var executors = await _dataContext.Executors.Where(x => x.DocumentId.Equals(id) && (x.StatusId == 1 || x.StatusId == 3))
            .FirstOrDefaultAsync();
        if (executors == null)
        {
            var document = await _dataContext.Documents.FindAsync(id);
            document!.StatusId = 4;
            await _dataContext.SaveChangesAsync();
        }
        if (executors is { StatusId: 3 })
        {
            var document = await _dataContext.Documents.FindAsync(id);
            document!.StatusId = 3;
            await _dataContext.SaveChangesAsync();
        }
      
        return Redirect($"/Document/GetById/{id}");
    }
}