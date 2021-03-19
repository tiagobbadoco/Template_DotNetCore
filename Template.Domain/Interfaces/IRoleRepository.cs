using System.Collections.Generic;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetAll();
    }
}
