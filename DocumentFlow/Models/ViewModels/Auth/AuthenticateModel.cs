using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Models.ViewModels.Auth;

public class AuthenticateModel
{
    [Required]
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }
}