using asc_general.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asc_general.Controllers
{
    public class healthController : Controller
    {

        private DbAscEntities db = new DbAscEntities();
        // GET: health
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.health = db.health_staff.ToList();
            return View(mymodel);
            
        }
    }
}