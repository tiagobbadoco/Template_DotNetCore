using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.ViewModels
{
    public class UserAuthResponseViewModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
