using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asc_general.Controllers
{
    public class healthController : Controller
    {
        // GET: health
        public ActionResult Index()
        {
            return View();
        }
    }
}