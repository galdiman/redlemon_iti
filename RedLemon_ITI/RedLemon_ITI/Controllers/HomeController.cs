using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedLemon_ITI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Instructions() {
            return View(Models.TemplateRepo.GetActivitiesByTemplate(1));
        }

        public ActionResult Question(int id) {
            return View(id);
        }
    }
}