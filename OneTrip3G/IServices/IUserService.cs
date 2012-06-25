using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.IServices
{
    public interface IUserService
    {
        IEnumerable<UserItem> GetUsers();
        bool AuthorizationUser(string userName, string password);
        bool CheckUserNameExist(string userName);
        string EncryptPassword(string password);
        void CreateUser(CreateUser viewModel);
        User GetUserById(int id);
        void DeleteUser(int id);
        int GetCount();
        void SaveUser();
    }
}
