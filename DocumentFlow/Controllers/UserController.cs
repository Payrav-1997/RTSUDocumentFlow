using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentFlow.Controllers;

public class UserController : BaseController
{
    private readonly DataContext _dataContext;

    public UserController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
       var userRoles = await _dataContext.Roles.ToListAsync();
       var departments = await _dataContext.Departments.ToListAsync();
       var list = new CreateUserViewModel()
       {
           Roles = userRoles,
           Departments = departments
       };
        return View(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel userViewModel)
    {
        var user = await GetByPhone(userViewModel.Phone);
        if (user != null)
        {
            ModelState.AddModelError("", "Такой пользователь уже существует!");
            return View(userViewModel);
        }
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            Logo = await AddFileAsync(nameof(User),userViewModel.Logo),
            Name = userViewModel.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password),
            Phone = userViewModel.Phone,
            Address = userViewModel.Address,
            Email = userViewModel.Email,
            CreatedAt = DateTime.UtcNow,
            RoleId = userViewModel.RoleId,
            DepartmentId = userViewModel.DepartmentId
        };
        await _dataContext.Users.AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll","User");
    }

    private async Task<User?> GetByPhone(string phone)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Phone.Equals(phone));
        return user;
    }

    private async Task<string> AddFileAsync(string dir, IFormFile file)
    {
        dir = dir.ToLower();
        var rootDirectory = Environment.GetEnvironmentVariable("WWWROOT_PATH");
        var fileDirectory = Path.Combine(rootDirectory, dir);
        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);
        var fileName = string.Concat(DateTime.Now.Ticks, file.FileName);
        var filePath = Path.Combine(fileDirectory, fileName);
        await using var fs = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fs);
        await fs.FlushAsync();
        fs.Close();
        return Path.Combine(dir,fileName);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(x=>x.Id.Equals(id));
            if (user == null)
        {
            ModelState.AddModelError("", "Такой пользователь не существует!");
            return View();
        }
        var newUser = new GetUserViewModel()
        {
            Logo = user.Logo,
            Name = user.Name,
            Phone = user.Phone,
            UserRole = user.Role.Name,
            Address = user.Address,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            Departament = user.Department!.Name
        };
        return View(newUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = _dataContext.Users.Select(x => new GetAllUserViewModel()
        {
            Id = x.Id,
            Address = x.Address,
            Departament = x.Department!.Name,
            Logo = x.Logo,
            Name = x.Name,
            UserRole = x.Role.Name
        }).ToList();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
        var userId = GetCurrentUserId();
        var user = await _dataContext.Users.FindAsync(userId);
        var newUser = new UpdateUserViewModel()
        {
            Id = user.Id,
            Address = user!.Address,
            Email = user.Email,
            Name = user.Name,
            Phone = user.Phone,
        };
        return View(newUser);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserViewModel model)
    {
        var user = await _dataContext.Users.FindAsync(model.Id);
        if (user == null)
        {
            ModelState.AddModelError("", "Такой пользователь не существует!");
            return View();
        }
        user!.Address = model.Address ?? user!.Address;
        user.Email = model.Email ?? user!.Email;
        user.Name = model.Name ?? user!.Name;
        user.Phone = model.Phone ?? user!.Phone;
        await _dataContext.SaveChangesAsync();
        return Redirect($"getById/{@user.Id}");
    }

    [HttpGet]
    public IActionResult UpdatePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model)
    {
        var userId = GetCurrentUserId();
        var user = await _dataContext.Users.FindAsync(userId);
        if (user == null)
        {
            ModelState.AddModelError("", "Такой пользователь не существует!");
            return View();
        }
        if (!BCrypt.Net.BCrypt.Verify(model.CurrentPassword, user?.Password))
        {
            ModelState.AddModelError("", "Пароль не корректный!");
            return View(model);
        }
        if (!model.Password.Equals(model.ConfirmPassword))
        {
            ModelState.AddModelError("", "Пароль не корректный!");
            return View(model);
        }
        user!.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        await _dataContext.SaveChangesAsync();
        return Redirect($"getById/{@user.Id}");
    }

   
}