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
            var user = repository.Get(m => m.Name.ToLower().Equals(userName.ToLower()) && m.Password.Equals(encryptPassword));
            return user != null;
        }

        public bool CheckUserNameExist(string userName)
        {
            var user = repository.Get(m => m.Name.Equals(userName));
            if (user != null)
                return false;
            else
                return true;
        }

        public string EncryptPassword(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        }

        public IEnumerable<UserItem> GetUsers()
        {
            var users = repository.GetAll();
            IList<UserItem> userItems = new List<UserItem>();
            foreach (var user in users)
            {
                userItems.Add(new UserItem
                {
                    Id = user.Id,
                    UserName = user.Name,
                });
            }
            return userItems.AsEnumerable<UserItem>();
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

        public void UpdateUser(User model)
        {
            var user = GetUserById(model.Id);
            user.Password = EncryptPassword(model.Password);
            repository.Update(user);
            SaveUser();
        }

        public void DeleteUser(int id)
        {
            var user = repository.Get(u => u.Id.Equals(id));
            repository.Delete(user);
            SaveUser();
        }

        public User GetUserById(int id)
        {
            var user = repository.Get(u => u.Id.Equals(id));
            return user;
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
