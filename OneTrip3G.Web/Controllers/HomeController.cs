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

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Install()
        //{
            //只能运行1次
            //添加一个初始用户
          //  if (MvcApplication.Settings.IsFirstRun)
          //  {
           //     var user = new CreateUser
          //      {
          //          UserName = "admin",
          //          Password = "admin",
          //          ConfirmPassword = "admin"
          //      };
        //
         //       userService.CreateUser(user);
         //       MvcApplication.Settings.IsFirstRun = false;
         //       return RedirectToAction("Index", "Home", new { @area = "Admin" } );
        //    }
         //   else
         //   {
        //        return RedirectToAction("Index");
       //     }
      //  }
    }
}
