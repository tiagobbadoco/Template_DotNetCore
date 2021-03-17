using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();

        #region "Authentication"
        User GetByEmailAsync(string email);

        bool CheckPassword(Guid id, string password);
        #endregion
    }
}
