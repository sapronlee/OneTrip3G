using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace OneTrip3G.Models
{
    public class LoginUser
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名必须填写。")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "密码必须填写。")]
        public string Password { get; set; }

        [DisplayName("记住我")]
        public bool RememberMe { get; set; }

        [DisplayName("验证码")]
        //[Required(ErrorMessage = "验证码必须填写。")]
        public string Captcha { get; set; }
    }

    public class CreateUser
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名必须填写。")]
        [Description("用户名必填且唯一，15个字符以内，只能是英文字母和数字。")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "用户名只能是5-15个字符之间。")]
        [Remote("CheckUserNameExist", "Users", "Admin", ErrorMessage = "用户名已经存在。")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "用户名只能是英文字母和数字。")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "密码必须填写。")]
        [Description("密码必填，15个字符以内，只能是英文字母和数字。")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "密码只能是5-15个字符之间。")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "密码只能是英文字母和数字。")]
        public string Password { get; set; }

        [DisplayName("确认密码")]
        [Description("确认密码必须与密码一致。")]
        [Compare("Password", ErrorMessage = "必须与密码一致。")]
        public string ConfirmPassword { get; set; }
    }

    public class EditUser
    {
        public int Id { get; set; }

        [DisplayName("新密码")]
        [Required(ErrorMessage = "新密码必须填写。")]
        [Description("新密码必填，15个字符以内，只能是英文字母和数字。")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "新密码只能是5-15个字符之间。")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "新密码只能是英文字母和数字。")]
        public string Password { get; set; }

        [DisplayName("确认密码")]
        [Description("确认密码必须与新密码一致。")]
        [Compare("Password", ErrorMessage = "必须与新密码一致。")]
        public string ConfirmPassword { get; set; }
    }

    public class UserItem
    {
        public int Id { get; set; }
        public String UserName { get; set; }
    }
}
