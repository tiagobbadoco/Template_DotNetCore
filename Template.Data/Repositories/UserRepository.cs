using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TemplateContext context)
           : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

        #region "Authentication"
        public User GetByEmailAsync(string email)
        {
            return Find(x => x.Email == email & !x.IsDeleted);
        }

        public bool CheckPassword(Guid id, string password)
        {
            User user = Find(x=> x.Id == id & !x.IsDeleted);

            return (user.Password == password);
        }
        #endregion
    }
}
