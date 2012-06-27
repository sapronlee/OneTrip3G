using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.IServices;
using OneTrip3G.Models;

namespace OneTrip3G.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private ISettingService settingService;

        public HomeController(IUserService userService, ISettingService settingService)
        {
            this.userService = userService;
            this.settingService = settingService;
        }

        public ActionResult Index()
        {
            if (userService.GetCount() == 0 && userService.CheckUserNameExist("admin"))
            {
                var user = new CreateUser
                {
                    UserName = "admin",
                    Password = "admin",
                    ConfirmPassword = "admin"
                };

                userService.CreateUser(user);
            }

            return View();
        }
    }
}
