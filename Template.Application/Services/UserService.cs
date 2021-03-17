using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(this.userRepository.GetAll());

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            if (userViewModel.Id != Guid.Empty)
                throw new Exception("UserID must be empty");

            Validator.ValidateObject(userViewModel, new ValidationContext(userViewModel), true);

            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);

            return true;
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
        #endregion

    }
}
