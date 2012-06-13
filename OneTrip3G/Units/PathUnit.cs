using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.Units
{
    public class PathUnit
    {
        public static string formatPath(string path)
        {
            string newPath = path;
            if (path.StartsWith("/"))
                newPath = path.Substring(1);
            if (path.EndsWith("/"))
                newPath = path.Substring(0, path.Length - 1);
            return newPath;
        }

        public static string MergePath(string firstPath, string secondPath)
        {
            firstPath = formatPath(firstPath);
            secondPath = formatPath(secondPath);

            return string.Format("{0}/{1}", firstPath, secondPath);
        }

        public static string MergeRootPath(string firstPath, string secondPath)
        {
            return string.Format("~/{0}", MergePath(firstPath, secondPath));
        }
    }
}
