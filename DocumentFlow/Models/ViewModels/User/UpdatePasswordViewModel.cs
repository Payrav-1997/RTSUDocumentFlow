using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Models.ViewModels.User;

public class UpdatePasswordViewModel
{
    [Required]
    public string CurrentPassword { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}