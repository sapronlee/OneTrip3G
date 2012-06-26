using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OneTrip3G.IServices;
using OneTrip3G.Attributes;
using OneTrip3G.Enums;

namespace OneTrip3G.Models
{
    public class SettingViewModel : ISetting
    {
        [DisplayName("名字")]
        [StringLength(20, ErrorMessage = "网站名字不能超过20个字符。")]
        [DefaultValue("OneTrip3G")]
        [Description("网站的名字，必填。")]
        [Required(ErrorMessage = "必须填写。")]
        [SettingStorage(StorageLocation.Database, "site-name")]
        public string SiteName { get; set; }

        [DisplayName("关键字")]
        [StringLength(100, ErrorMessage = "网站关键字不能超过100个字符。")]
        [DefaultValue("OneTrip, 3G, Ytrip, 壹旅游。")]
        [Description("网站的关键字，每个关键字中间以半角“,”隔开。必填。")]
        [Required(ErrorMessage = "必须填写。")]
        [SettingStorage(StorageLocation.Database, "keywords")]
        public string Keywords { get; set; }

        [DisplayName("描述")]
        [StringLength(100, ErrorMessage = "网站描述不能超过100个字符。")]
        [DefaultValue("壹旅游是一家专业的旅游信息数字多媒体内容提供商。")]
        [Description("网站的描述，100字以内。必填。")]
        [Required(ErrorMessage = "必须填写。")]
        [SettingStorage(StorageLocation.Database, "description")]
        public string Description { get; set; }

        [DisplayName("上传根目录")]
        [StringLength(100, ErrorMessage = "上传目录不能超过100个字符。")]
        [DefaultValue("/Uploads")]
        [Description("网站内容的上传根目录，100个字符以内，不能出现'\'。")]
        [Required(ErrorMessage = "必须填写。")]
        [SettingStorage(StorageLocation.Database, "uploadPath")]
        public string UploadPath { get; set; }

        [DisplayName("视频目录")]
        [StringLength(20, ErrorMessage = "视频目录不能超过20个字符。")]
        [DefaultValue("/Videos")]
        [Required(ErrorMessage = "必须填写。")]
        [Description("网站视频的上传根目录，20个字符以内，以上传目录为起点。")]
        [SettingStorage(StorageLocation.Database, "videoUploadDir")]
        public string VideoUploadDir { get; set; }

        [DisplayName("地图目录")]
        [StringLength(20, ErrorMessage = "地图目录不能超过20个字符。")]
        [DefaultValue("/Maps")]
        [Required(ErrorMessage = "必须填写。")]
        [Description("网站地图的上传根目录，20个字符以内，以上传目录为起点。")]
        [SettingStorage(StorageLocation.Database, "mapUploadDir")]
        public string MapUploadDir { get; set; }

        [DisplayName("分页数")]
        [Range(1, 100, ErrorMessage = "只能是1-100之间的数字。")]
        [DefaultValue(10)]
        [Required(ErrorMessage = "必须填写。")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage ="只能是数字。")]
        [Description("后台列表页面分页显示的个数，只能是数字。")]
        [SettingStorage(StorageLocation.Database, "listpagesize")]
        public int ListPageSize { get; set; }

        [DisplayName("地图缩略图宽度")]
        [DefaultValue(300)]
        [Required(ErrorMessage = "必须填写。")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "只能是数字。")]
        [Description("地图缩略图的宽度，单位px。")]
        [SettingStorage(StorageLocation.Database, "mapthumbnailwidth")]
        public int MapThumbnailWidth { get; set; }

        [DisplayName("是否是第一次运行程序")]
        [DefaultValue(true)]
        [SettingStorage(StorageLocation.Database, "isfirstrun")]
        public bool IsFirstRun { get; set; }
    }
}
