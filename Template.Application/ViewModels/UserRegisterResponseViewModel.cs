using System.Collections.Generic;

namespace Template.Application.ViewModels
{
    public class UserRegisterResponseViewModel
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
