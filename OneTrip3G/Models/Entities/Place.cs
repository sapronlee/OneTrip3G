using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.Models.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string VideoFile { get; set; }
        public int VideoSize { get; set; }
        public string MapFile { get; set; }
        public int MapSize { get; set; }
        public string MapThumbnailFile { get; set; }
        public int MapThumbnailSize { get; set; }
        public string Body { get; set; }
    }
}
