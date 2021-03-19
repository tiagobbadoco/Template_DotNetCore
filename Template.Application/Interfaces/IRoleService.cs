using System.Collections.Generic;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAll();
        RoleViewModel GetById(string id);
        bool Post(RoleViewModel role);
        bool Put(RoleViewModel role);
        bool Delete(string id);
    }
}
