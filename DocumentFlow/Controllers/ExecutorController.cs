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
        var users = _dataContext.Users.Where(x=>x.Id != currentUserId).ToList();
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
        var executor = new Executor()
        {
            Code = model.Code,
            Description = model.Description,
            DocumentId = model.DocumentId,
            StatusId = 1,
            CreatedAt = DateTime.UtcNow,
            ExecutionTime = DateTime.UtcNow,
            ExecutorRole = model.ExecutorRole,
            UsersId = model.UserId,
            DateOfOrder = DateTime.UtcNow
        };
        await _dataContext.AddAsync(executor);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll","Document");
    }
}