using System.Collections.Generic;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        UserViewModel GetById(string id);
        bool Put(UserViewModel userViewModel);
        bool Delete(string id);

        #region "Authentication"
        UserViewModel FindByEmail(string email);
        bool CheckPassword(UserViewModel user, string password);
        UserRegisterResponseViewModel Register(UserRegisterRequestViewModel user);
        #endregion
    }
}
