using System.Data.Entity;
using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Statistics;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Админ,Сотрудник")]
    public IActionResult StatisticsCount()
    {
        var userCount =  _dataContext.Users.Count();
        var departmentCount =  _dataContext.Departments.Count();
        var documentsCount =  _dataContext.Documents.Count();
        var data = new GetStatisticsViewModel()
        {
            DepartmentCount = departmentCount,
            UserCount = userCount,
            DocumentCount = documentsCount
        };
        return View(data);
    }
}