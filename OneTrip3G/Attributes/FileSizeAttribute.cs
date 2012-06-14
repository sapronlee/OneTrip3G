using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Globalization;

namespace OneTrip3G.Attributes
{
    public class FileSizeAttribute : ValidationAttribute
    {
        public FileSizeAttribute(int maxSize)
            : base("超出大小")
        {
            MaxSize = maxSize;
        }

        public int MaxSize { get; set; }

        public override bool IsValid(object value)
        {
            bool result = false;
            var file = value as HttpPostedFileBase;

            if (file != null)
            {
                if (file.ContentLength < MaxSize * 1024)
                    result = true;
                else
                    result = false;
            }
            else
                result = true;
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, MaxSize);
        }
    }
}
