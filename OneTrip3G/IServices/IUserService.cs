using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneTrip3G.Models;

namespace OneTrip3G.IServices
{
    public interface IUserService
    {
        bool AuthorizationUser(string userName, string password);
        string EncryptPassword(string password);
        void CreateUser(CreateUser viewModel);
        void SaveUser();
    }
}
