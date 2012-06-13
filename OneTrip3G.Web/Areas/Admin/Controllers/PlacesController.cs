using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using OneTrip3G.IServices;
using OneTrip3G.Models;
using OneTrip3G.Web.Extensions;
using OneTrip3G.Models.Entities;

namespace OneTrip3G.Web.Areas.Admin.Controllers
{
    public class PlacesController : BaseController
    {
        private readonly IPlaceService service;

        public PlacesController(IPlaceService service)
        {
            this.service = service;
        }

        public ActionResult Index(int? page)
        {
            var places = service.GetPlaces().ToPagedList(page.HasValue ? page.Value -1 : 0, MvcApplication.Settings.ListPageSize);
            return View(places);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePlace createPlace)
        {
            if (ModelState.IsValid)
            {
                service.CreatePlace(createPlace);
                return RedirectToAction("Index").AndNotice("添加成功！");
            }
            return View(createPlace);
        }

        public ActionResult Edit(int id)
        {
            var place = service.GetPlace(id);
            return View(place);
        }

        [HttpPost]
        public ActionResult Edit(EditPlace model)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePlace(model);
                return RedirectToAction("Index").AndNotice("修改成功！");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            service.DeletePlace(id);
            return RedirectToAction("Index").AndNotice("删除成功！");
        }

        public JsonResult CheckUrlKeyExist(string urlKey)
        {
            var result = service.CheckPlaceExist(urlKey);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
