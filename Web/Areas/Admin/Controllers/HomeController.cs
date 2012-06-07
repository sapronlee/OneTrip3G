using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.IRepositories;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IPlaceRepository placeRepository;

        public HomeController(IPlaceRepository repository)
        {
            this.placeRepository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
