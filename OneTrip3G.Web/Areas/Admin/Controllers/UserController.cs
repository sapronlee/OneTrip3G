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
    public class UserController : Controller
    {
        private readonly IUserService userService;
        //
        // GET: /Admin/User/
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //用户列表
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        //注册用户
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                userService.CreateUser(model);
                return RedirectToAction("Index").AndNotice("注册成功！");
            }
            return View(model);
        }

        //修改密码
        public ActionResult Edit(int id) 
        {
            EditUser editUser = new EditUser();
            editUser.Id = id;
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(EditUser model)
        {
            if (ModelState.IsValid)
            {
                User user = userService.GetUserById(model.Id);
                user.Password = model.Password;
                userService.UpdateUser(user);
                return RedirectToAction("Index").AndNotice("密码修改成功！");
            }
            return View(model);
        }

        //删除用户
        public ActionResult Delete(int id)
        {
            User user = userService.GetUserById(id);
            String cookieName = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            if (!cookieName.Equals(user.Name))
            {
                userService.DeleteUser(id);
                return RedirectToAction("Index").AndNotice("删除成功！");
            }
            else
            {
                return RedirectToAction("Index").AndAlert("删除失败！不能删除当前登录用户！");
            }
        }

        //验证用户名是否存在
        public ActionResult CheckUserNameExist(String userName)
        {
            var result = userService.CheckUserNameExist(userName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
