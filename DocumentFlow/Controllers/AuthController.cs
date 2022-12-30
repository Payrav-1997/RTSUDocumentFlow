using System.Data.Entity;
using System.Security.Claims;
using DocumentFlow.Models;
using DocumentFlow.Models.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFlow.Controllers;

public class AuthController : BaseController
{
    private readonly DataContext _context;

    public AuthController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AuthenticateModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = await _context.Users.FirstOrDefaultAsync(x=>x.Phone.Equals(model.Phone));
        if (user == null)
        {
            ModelState.AddModelError("", "Логин или пароль не корректный!");
            return View(model);
        }
        if (!BCrypt.Net.BCrypt.Verify(model.Password, user?.Password))
        {
            ModelState.AddModelError("", "Логин или пароль не корректный!");
            return View(model);
        }
        Authenticate(user.Phone, user.Id, user.Role.Name);
        return Redirect("Home/Index");
      
    }
    
    
    private async void Authenticate(string phone,Guid Id,string role)
    {
        var list = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, phone),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
            new Claim(ClaimTypes.NameIdentifier, Id.ToString())
        };
        var id = new ClaimsIdentity(list, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        // authentication successful so return user details without password

    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        return RedirectToAction("Login", "Auth");
    }
}
