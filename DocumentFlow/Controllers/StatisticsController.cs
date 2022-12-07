using System.Data.Entity;
using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class StatisticsController : BaseController
{
    private readonly DataContext _dataContext;

    public StatisticsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> StatisticsCount()
    {
        var userCount =  _dataContext.Users.Count();
        var departmentCount =  _dataContext.Departments.Count();
        var data = new GetStatisticsViewModel()
        {
            DepartmentCount = departmentCount,
            UserCount = userCount
        };
        return View(data);
    }
}