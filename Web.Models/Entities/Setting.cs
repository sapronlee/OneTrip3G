using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Entities
{
    [NotMapped]
    public class Setting
    {
        private static readonly Setting instance = new Setting();

        private Setting() { }

        public static Setting Instance
        {
            get { return instance; }
        }

        public string SiteName 
        {
            get { return "你好"; }
            set { SiteName = value; }
        }
        public string SiteKeyWords { get; set; }
        public string SiteDescription { get; set; }
    }
}
