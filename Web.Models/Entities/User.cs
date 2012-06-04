using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户名（必填，唯一）
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必须填写")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "只能在4到20个字符之间")]
        [RegularExpression(@"^.[A-Za-z0-9]+$", ErrorMessage = "只能是英文字母和数字")]
        public string Name { get; set; }

        /// <summary>
        /// 密码（必填）
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "必须填写")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "只能在6到32个字符之间")]
        public string Password { get; set; }
    }
}
