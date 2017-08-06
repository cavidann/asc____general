using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asc_general.Controllers.Controllers
{
    public class MemorizedController : Controller
    {
        // GET: Memorized
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
    }
}