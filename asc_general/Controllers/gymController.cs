using asc_general.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asc_general.Controllers
{
    public class gymController : Controller
    {
        private ascEntities db = new ascEntities();
        // GET: gym
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.gym = db.gym_blog.ToList();
            mymodel.idman = db.idman_kompp.ToList();
            return View(mymodel);
            
        }
    }
}