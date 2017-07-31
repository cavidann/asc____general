using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;

namespace asc_general.Controllers
{
   public class EducationController : Controller
    {
        // GET: Education
         private DbAscEntities db = new DbAscEntities();
        public ActionResult Index()
        {
            dynamic datalar = new ExpandoObject();
            datalar.EduCategory = db.edu_categories.OrderBy(cat => cat.sira).ToList();
            datalar.Education = db.educations.ToList();
            datalar.edu_blog = db.blogs.Where(e => e.blog_category.name.Equals("Tehsil")).OrderByDescending(e => e.date).Take(3).ToList();
            return View(datalar);
        }
    }
}