using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asc_general.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Food()
        {
            ViewBag.Message = "foooooood";

            return View();
        }
        public ActionResult Cartoon()
        {
            ViewBag.Message = "cartoon";

            return View();
        }
    }
}