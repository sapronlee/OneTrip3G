using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OneTrip3G.Units
{
    public class FileUploads
    {
        public static char DirSeparator = Path.DirectorySeparatorChar;

        public static string UploadFile(HttpPostedFileBase file, string uploadPath, string newName)
        {
            if (file == null) return null;
            if (file.ContentLength < 0) return null;

            var fileName = file.FileName;
            var fileExtName = Path.GetExtension(fileName);
            if (fileExtName == null) return null;

            if (newName != null)
            {
                fileName = newName + fileExtName;
            }

            //如果上传文件夹不存在则创建
            if (!uploadPath.StartsWith("~/"))
            {
                uploadPath = string.Format("~/{0}", uploadPath);
            }
            var physicsPath = HttpContext.Current.Server.MapPath(uploadPath);
            if (!Directory.Exists(physicsPath))
                Directory.CreateDirectory(physicsPath);

            var filePath = string.Format("{0}{1}{2}", physicsPath, DirSeparator, fileName);

            var fullPath = Path.GetFullPath(filePath);

            //保存
            file.SaveAs(fullPath);
            
            return string.Format("{0}/{1}", uploadPath, fileName);
        }

        public static void DeleteFile(string file)
        {
            if (file.Length == 0) return;
            var fullPath = HttpContext.Current.Server.MapPath(file);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static string UploadFile(HttpPostedFileBase file, string uploadPath, string newName, int width)
        {
            if (file == null) return null;
            if (file.ContentLength < 0) return null;

            var fileName = file.FileName;
            var fileExtName = Path.GetExtension(fileName);
            if (fileExtName == null) return null;

            if (newName != null)
            {
                fileName = newName + fileExtName;
            }

            //如果上传文件夹不存在则创建
            if (!uploadPath.StartsWith("~/"))
            {
                uploadPath = string.Format("~/{0}", uploadPath);
            }
            var physicsPath = HttpContext.Current.Server.MapPath(uploadPath);
            if (!Directory.Exists(physicsPath))
                Directory.CreateDirectory(physicsPath);

            var filePath = string.Format("{0}{1}{2}", physicsPath, DirSeparator, fileName);

            var fullPath = Path.GetFullPath(filePath);

            FileStream stream = new FileStream(Path.GetFullPath(filePath), FileMode.OpenOrCreate);
  
            Image OrigImage = Image.FromStream(file.InputStream);
            
            //计算height
            var height = OrigImage.Height * width / OrigImage.Width;

            Bitmap TempBitmap = new Bitmap(width, height);
            
            Graphics NewImage = Graphics.FromImage(TempBitmap);
            NewImage.CompositingQuality = CompositingQuality.HighQuality;
            NewImage.SmoothingMode = SmoothingMode.HighQuality;
            NewImage.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Rectangle imageRectangle = new Rectangle(0, 0, width, height);
            NewImage.DrawImage(OrigImage, imageRectangle);

            TempBitmap.Save(stream, OrigImage.RawFormat);

            NewImage.Dispose();
            TempBitmap.Dispose();
            OrigImage.Dispose();
            stream.Close();
            stream.Dispose();

            return string.Format("{0}/{1}", uploadPath, fileName);
        }
    }
}
