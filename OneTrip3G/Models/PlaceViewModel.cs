using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OneTrip3G.Attributes;
using System.IO;
using System.Web;

namespace OneTrip3G.Models
{
    public class PlaceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public bool HasVideo { get; set; }
        public bool HasMap { get; set; }
    }

    public class CreatePlace
    {
        public int Id { get; set; }

        [DisplayName("景点名")]
        [Required(ErrorMessage = "景区名字必须填写。")]
        [Description("景点的中文名字，必填，20个字符以内。")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "景区名只能是2-20个字符之间。")]
        public string Name { get; set; }

        [DisplayName("关键字")]
        [Required(ErrorMessage = "关键字必须填写。")]
        [Description("景点的关键字，必填且唯一，20个字符以内。")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "关键字只能是2-20个字符之间。")]
        [Remote("CheckUrlKeyExist", "Places", "Admin", ErrorMessage = "关键字已经存在。")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "关键字只能是英文字母和数字。")]
        [UniqueOfPlaceKey(ErrorMessage = "关键字已经存在。")]
        public string UrlKey { get; set; }

        [DisplayName("视频")]
        [Required(ErrorMessage = "请选择视频文件。")]
        [Description("景点的视频，小于20M。")]
        [FileType(@"mp4", ErrorMessage = "只能是mp4的视频。")]
        [FileSize(20480, ErrorMessage = "视频文件超出20M大小，请重新选择文件。")]
        public HttpPostedFileBase VideoFile { get; set; }
        
        [DisplayName("地图")]
        [Required(ErrorMessage = "请选择地图文件。")]
        [Description("景点的地图，小于5M。")]
        [FileType(@"jpg|png", ErrorMessage = "只能是jpg或者png的图片。")]
        [FileSize(5120, ErrorMessage = "地图文件超出5M大小，请重新选择文件。")]
        public HttpPostedFileBase MapFile { get; set; }
    }

    public class EditPlace
    {
        public int Id { get; set; }

        [DisplayName("景区名")]
        [Required(ErrorMessage = "景区名字必须填写。")]
        [Description("景点的中文名字，必填，20个字符以内。")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "景区名只能是2-20个字符之间。")]
        public string Name { get; set; }

        [DisplayName("关键字")]
        public string UrlKey { get; set; }

        [DisplayName("视频")]
        [Description("景点的视频，小于20M。")]
        [FileType(@"mp4", ErrorMessage = "只能是mp4的视频。")]
        [FileSize(20480, ErrorMessage = "视频文件超出20M大小，请重新选择文件。")]
        public HttpPostedFileBase VideoFile { get; set; }

        [DisplayName("地图")]
        [Description("景点的地图，小于5M。")]
        [FileType(@"jpg|png", ErrorMessage = "只能是jpg或者png的图片。")]
        [FileSize(5120, ErrorMessage = "地图文件超出5M大小，请重新选择文件。")]
        public HttpPostedFileBase MapFile { get; set; }

        public string Video { get; set; }
        public string Map { get; set; }
    }

    public class ShowPlace
    {
        public string UrlKey { get; set; }
        public string Name { get; set; }
        public string VideoFile { get; set; }
        public string MapFile { get; set; }
        public string MapThumbnailFile { get; set; }
    }
}
