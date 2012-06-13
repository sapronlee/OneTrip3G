using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.IServices;
using OneTrip3G.Models;
using OneTrip3G.Web.Extensions;

namespace OneTrip3G.Web.Areas.Admin.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ISettingService provider;

        public SettingsController(ISettingService provider)
        {
            this.provider = provider;
        }

        public ActionResult Index()
        {
            var settings = provider.GetSettings<SettingViewModel>();
            return View(settings);
        }

        [HttpPost]
        public ActionResult Index(SettingViewModel setting)
        {
            if (ModelState.IsValid)
            {
                provider.SaveSettings<SettingViewModel>(setting);
                return RedirectToAction("Index").AndNotice("保存成功！");
            }
            return View();
        }
    }
}
