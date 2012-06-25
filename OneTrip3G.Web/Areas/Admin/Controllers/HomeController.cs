using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Models;
using OneTrip3G.Models.Entities;
using OneTrip3G.IServices;
using System.Web.Security;
using OneTrip3G.Web.Extensions;

namespace OneTrip3G.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPlaceService placeService;
        private readonly IUserService userService;

        public HomeController(IPlaceService placeService, IUserService userService)
        {
            this.placeService = placeService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var model = new AdminHomeModel
            {
                PlaceCount = placeService.GetCount(),
                UserCount = userService.GetCount()
            };
            return View(model);
        }

        [Authorize]
        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Register(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                userService.CreateUser(model);
                return RedirectToAction("ShowUser").AndNotice("注册成功！");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowUser()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = userService.GetUserById(id);
            String cookieName = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            if (!cookieName.Equals(user.Name))
            {
                userService.DeleteUser(id);
                return RedirectToAction("ShowUser").AndNotice("删除成功！");
            }
            else
            {
                return RedirectToAction("ShowUser").AndNotice("删除失败！不能删除当前登录用户！");
            }
        }

        public ActionResult CheckUserNameExist(String userName)
        {
            var result = userService.CheckUserNameExist(userName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
