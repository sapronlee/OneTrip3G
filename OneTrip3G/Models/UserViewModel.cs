using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
