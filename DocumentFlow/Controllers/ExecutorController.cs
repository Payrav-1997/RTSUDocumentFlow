using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Executor;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class ExecutorController : BaseController
{
    private readonly DataContext _dataContext;

    public ExecutorController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Create(Guid id)
    {
        var currentUserId = GetCurrentUserId();
        var users = _dataContext.Users.Where(x=>x.Id != currentUserId).OrderBy(x=>x.CreatedAt).ToList();
        var executor = new CreateExecutorViewModel()
        {
            Users = users,
            DocumentId = id
        };
        return View(executor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExecutorViewModel model)
    {
        
        foreach (var userId in model.UserId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            var executor = new Executor()
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Description = model.Description,
                DocumentId = model.DocumentId,
                StatusId = 1,
                CreatedAt = DateTime.UtcNow,
                ExecutionTime = model.ExecutionTime,
                ExecutorRole = user!.Role.Name,
                UserId = userId,
                DateOfOrder = DateTime.UtcNow
            };
            await _dataContext.AddAsync(executor);
            await _dataContext.SaveChangesAsync();
            var notion = new Notion()
            {
                Id = Guid.NewGuid(),
                Message = executor.Description,
                UserId = userId
            };
            await _dataContext.AddAsync(notion);
            await _dataContext.SaveChangesAsync();
        }

       
        
        return RedirectToAction("GetAll","Document");
    }
}