using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.IServices;
using OneTrip3G.IRepositories;
using OneTrip3G.Infrastructure;
using System.Web.Security;
using OneTrip3G.Models;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public bool AuthorizationUser(string userName, string password)
        {
            var encryptPassword = EncryptPassword(password);
            var user = repository.Get(m => m.Name.Equals(userName) && m.Password.Equals(encryptPassword));
            return user != null;
        }


        public string EncryptPassword(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        }


        public void CreateUser(CreateUser viewModel)
        {
            var user = new User
            {
                Name = viewModel.UserName,
                Password = EncryptPassword(viewModel.Password)
            };
            repository.Add(user);
            SaveUser();
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }


        public int GetCount()
        {
            return repository.GetAll().Count();
        }
    }
}
