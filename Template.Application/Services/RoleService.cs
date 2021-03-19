using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public List<RoleViewModel> GetAll()
        {
            return mapper.Map<List<RoleViewModel>>(this.roleRepository.GetAll());
        }

        public RoleViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid roleId))
                throw new Exception("RoleId is not valid");
            
            return mapper.Map<RoleViewModel>(this.roleRepository.Find(x => x.Id == roleId & !x.IsDeleted));
        }

        public bool Post(RoleViewModel role)
        {
            if (role.Id != Guid.Empty)
                throw new Exception("RoleId must be empty");

            Role _role = mapper.Map<Role>(role);

            return roleRepository.Create(_role) != null;
        }

        public bool Put(RoleViewModel role)
        {
            if (role.Id == Guid.Empty)
                throw new Exception("Invalid RoleId");

            if (roleRepository.Find(x => x.Id == role.Id & !x.IsDeleted) == null)
                throw new Exception("Role not found");

            return roleRepository.Update(mapper.Map<Role>(role));
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid roleId))
                throw new Exception("RoleId is not valid");

            if (roleRepository.Find(x => x.Id == roleId & !x.IsDeleted) == null)
                throw new Exception("Role not found");

            return roleRepository.Delete(roleId);
        }
    }
}
