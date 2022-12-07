using System.Data.Entity;
using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class DepartmentController : BaseController
{
    private readonly DataContext _dataContext;

    public DepartmentController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDepartmentViewModel model)
    {
        var department =  _dataContext.Departments.FirstOrDefault(x => x.Name.Equals(model.Name));
        if (department != null)
        {
            ModelState.AddModelError("", "Такой отдел уже существует!");
            return View(model);
        }

        var res = new Department()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            CreatedAt = DateTime.UtcNow
        };
        await _dataContext.AddAsync(res);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll", "Department");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _dataContext.Users.FindAsync(GetCurrentUserId());
        var departments =  _dataContext.Departments.Select(x => new GetDepartmentViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            CreatedAt = x.CreatedAt,
            UserRole = user!.Roles.Name
        }).ToList();
        return View(departments);
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartmentUsers(Guid id)
    {
        var userId = GetCurrentUserId();
        var departmentUsers =  _dataContext.Users.Where(x =>x.Id != userId && x.DepartmentId.Equals(id))
            .Select(x => new GetDepartmentUsersDto()
            {
                Id = x.Id,
                Email = x.Email,
                Logo = x.Logo,
                Name = x.Name,
                Phone = x.Phone,
                AdminId = userId
            }).ToList();
        return View(departmentUsers);
    }

}