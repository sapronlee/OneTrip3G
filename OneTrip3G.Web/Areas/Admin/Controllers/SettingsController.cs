using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.IProviders;
using OneTrip3G.Models;

namespace OneTrip3G.Web.Areas.Admin.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ISettingProvider provider;

        public SettingsController(ISettingProvider provider)
        {
            this.provider = provider;
        }

        public ActionResult Index()
        {
            var settings = provider.GetGlobalSettings<SettingModel>();
            return View(settings);
        }

        [HttpPost]
        public ActionResult Index(SettingModel setting)
        {
            if (ModelState.IsValid)
            {
                provider.SaveGlobalSettings<SettingModel>(setting);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
