using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.IServices;
using OneTrip3G.Models;

namespace OneTrip3G.Web.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlaceService placeService;

        public PlacesController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public ActionResult Show(string urlKey)
        {
            var place = placeService.GetByUrlKey(urlKey);
            var placeViewModel = new ShowPlace
            {
                UrlKey = place.EnglishName,
                Name = place.Name,
                VideoFile = place.VideoFile,
                MapFile = place.MapFile,
                MapThumbnailFile = place.MapThumbnailFile
            };
            return View(placeViewModel);
        }

        public ActionResult Map(string urlKey)
        {
            var place = placeService.GetByUrlKey(urlKey);
            var placeViewModel = new ShowPlace
            {
                UrlKey = place.EnglishName,
                Name = place.Name,
                VideoFile = place.VideoFile,
                MapFile = place.MapFile,
                MapThumbnailFile = place.MapThumbnailFile
            };
            return View(placeViewModel);
        }

    }
}
