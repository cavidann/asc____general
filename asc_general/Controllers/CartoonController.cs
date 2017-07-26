using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using asc_general.Models;

namespace asc_general.Controllers
{
    public class CartoonController : Controller
    {
        private ascEntities1 db = new ascEntities1();
        // GET: Cartoon
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.cartoon = db.cartoons.ToList();
            return View(mymodel);
        }

    }
}