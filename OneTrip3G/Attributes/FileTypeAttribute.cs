using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace OneTrip3G.Attributes
{
    public class FileTypeAttribute : ValidationAttribute
    {
        public FileTypeAttribute(string pattern) : base("类型错误") 
        {
            this.Pattern = pattern;
        }

        public string Pattern { get; set; }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
                return true;

            var extensionName = Path.GetExtension(file.FileName).Substring(1);
            if (Regex.IsMatch(extensionName, this.Pattern, RegexOptions.IgnoreCase))
                return true;
            else
                return false;
        }
    }
}
