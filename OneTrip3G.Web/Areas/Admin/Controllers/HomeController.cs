using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Models;
using OneTrip3G.Models.Entities;
using OneTrip3G.IServices;
using System.Web.Security;
using OneTrip3G.Web.Extensions;

namespace OneTrip3G.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPlaceService placeService;
        private readonly IUserService userService;

        public HomeController(IPlaceService placeService, IUserService userService)
        {
            this.placeService = placeService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var model = new AdminHomeModel
            {
                PlaceCount = placeService.GetCount(),
                UserCount = userService.GetCount()
            };
            return View(model);
        }
    }
}
