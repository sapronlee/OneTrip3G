using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OneTrip3G.IProviders;
using OneTrip3G.Attributes;
using OneTrip3G.Enums;

namespace OneTrip3G.Models
{
    public class GlobalSetting : ISetting
    {
        [DisplayName("网站名字")]
        [StringLength(200)]
        [DefaultValue("OneTrip3G")]
        [Description("网站的名字")]
        [SettingStorage(StorageLocation.Database, "site-name")]
        public string SiteName { get; set; }

        [DisplayName("网站关键字")]
        [StringLength(200)]
        [DefaultValue("OneTrip, 3G, Ytrip, 壹旅游")]
        [Description("网站的关键字")]
        [SettingStorage(StorageLocation.Database, "keywords")]
        public string Keywords { get; set; }

        [DisplayName("网站描述")]
        [StringLength(200)]
        [DefaultValue("壹旅游是一家专业的旅游信息数字多媒体内容提供商")]
        [Description("网站的描述")]
        [SettingStorage(StorageLocation.Database, "description")]
        public string Description { get; set; }
    }
}
