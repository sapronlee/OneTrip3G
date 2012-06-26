using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Models;
using OneTrip3G.IServices;
using System.Web.Security;
using OneTrip3G.Units;

namespace OneTrip3G.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Login()
        {
            //var model = new CreateUser
            //{
            //    UserName = "admin",
            //    Password = "admin"
            //};
            //userService.CreateUser(model);
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (userService.AuthorizationUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    //重定向
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
                        && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith("/\\"))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误!");
                }
            }
            return View(model);
        }

        //注销
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        //生成验证码图片
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        //验证 验证码输入是否正确
        public ActionResult CheckUserCaptcha(String captcha)
        {
            var result = Session["ValidateCode"].ToString().Equals(captcha) ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
