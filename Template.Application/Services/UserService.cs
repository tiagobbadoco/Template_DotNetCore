using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Template.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(this.userRepository.GetAll());

            return _userViewModels;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("ID is invalid");

            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            _user = mapper.Map<User>(userViewModel);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            return this.userRepository.Delete(_user);
        }

        #region "Authentication"
        public UserViewModel FindByEmail(string email)
        {
            return  mapper.Map<UserViewModel>(this.userRepository.GetByEmailAsync(email));
        }

        public bool CheckPassword(UserViewModel user, string password)
        {
            return this.userRepository.CheckPassword(user.Id, password);
        }

        public UserRegisterResponseViewModel Register(UserRegisterRequestViewModel user)
        {
            User _user = mapper.Map<User>(user);

            if (this.userRepository.Find(x => x.Email == _user.Email & !x.IsDeleted) != null)
                return new UserRegisterResponseViewModel { IsSuccessfulRegistration = false, Errors = new List<string> { "Já existe usuário cadastrado para esse email" } };

            _user.DateCreated = DateTime.Now;


            try
            {

                this.userRoleRepository.Create(new UserRole
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    UserId = userRepository.Create(_user).Id,
                    RoleId = roleRepository.Find(x => x.Name == "User" & !x.IsDeleted).Id
                }); ;

                return new UserRegisterResponseViewModel { IsSuccessfulRegistration = true };
            }
            catch (Exception e)
            {
                return new UserRegisterResponseViewModel { IsSuccessfulRegistration = false, Errors = new List<string> { e.Message } };
            }
        }
        #endregion

        #region "Auth"
        public List<RoleViewModel> GetRoles(string id)
        {
            List<Role> roles = roleRepository.Query(x => !x.IsDeleted).ToList();
            List<UserRole> userRoles = userRoleRepository.Query(x => !x.IsDeleted & x.UserId == Guid.Parse(id)).ToList();

            List<RoleViewModel> response = new List<RoleViewModel>();

            foreach(Role role in roles)
            {
                if (userRoles.Find(x => x.RoleId == role.Id) != null)
                    response.Add(new RoleViewModel { Id = role.Id, Name = role.Name });
            }

            return response;
        }
        #endregion
    }
}
