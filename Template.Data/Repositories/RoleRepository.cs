using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(TemplateContext context)
            : base(context) { }

        public IEnumerable<Role> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
