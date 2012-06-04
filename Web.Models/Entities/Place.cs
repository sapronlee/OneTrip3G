using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Entities
{
    public class Place
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        [Display(Name = "中文名")]
        [Required(ErrorMessage = "必须填写")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "只能在1到20个字符之间")]
        public string Name { get; set; }
        /// <summary>
        /// 英文名（主要使用于Url，唯一）
        /// </summary>
        [Display(Name = "英文名")]
        [Required(ErrorMessage = "必须填写")]
        [RegularExpression(@"^.[A-Za-z0-9]+$", ErrorMessage = "只能是英文字母和数字")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "只能在2到20个字符之间")]
        public string EnglishName { get; set; }
        
        /// <summary>
        /// 视频文件地址
        /// </summary>
        [Display(Name = "视频")]
        public string VideoFile { get; set; }
        
        /// <summary>
        /// 视频文件大小
        /// </summary>
        [Display(Name = "视频大小")]
        public int VideoSize { get; set; }
        /// <summary>
        /// 地图文件地址
        /// </summary>
        [Display(Name = "地图")]
        public string MapFile { get; set; }
        /// <summary>
        /// 地图文件大小
        /// </summary>
        [Display(Name = "地图大小")]
        public int MapSize { get; set; }
    }
}
