using DocumentFlow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class NotionController : BaseController
{
    private readonly DataContext _dataContext;

    public NotionController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notion = await _dataContext.Notions.FindAsync(id);
        if (notion == null)
        {
            return RedirectToAction("StatisticsCount", "Statistics");
        }
        _dataContext.Remove(notion);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
}