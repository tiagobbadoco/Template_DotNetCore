using System.ComponentModel.DataAnnotations;

namespace Template.Application.ViewModels
{
    public class UserAuthRequestViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
