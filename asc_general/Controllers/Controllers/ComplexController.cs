using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;
using System.Net;
using PagedList;

namespace asc_general.Controllers.Controllers
{
    public class ComplexController : Controller
    {
        private DbAscEntities db = new DbAscEntities();
        // GET: Complex
        public ActionResult Index(int? id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic mymodel = new ExpandoObject();
            our_complex complex_id = db.our_complex.Find(id);
            mymodel.complexId = complex_id;
            mymodel.regions = db.regions.ToList();
            mymodel.next = db.our_complex.FirstOrDefault(n => n.id > complex_id.id);
            mymodel.prev = db.our_complex.FirstOrDefault(p => p.id < complex_id.id);
            return View(mymodel);
        }
    }
}