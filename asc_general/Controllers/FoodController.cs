using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using asc_general.Models;

namespace asc_general.Controllers
{   
    
    public   class FoodController : Controller
    {
        private ascEntities1 db = new ascEntities1();
        // GET: Food
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.food_cat = db.food_categories.ToList();
            model.foods = db.foods.ToList();
            return View(model);
        }

    }
}