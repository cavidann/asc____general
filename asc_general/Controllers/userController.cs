using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;
using System.Net;

namespace asc_general.Controllers
{
    public class userController : Controller
    {  
        private DbAscEntities db = new DbAscEntities();
        // GET: user 
        public ActionResult Index(int? id)
        {   
        
            if (Session["user"] != null)
            {
                //if (id == null)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                //dynamic mymodel = new ExpandoObject();
                //user  user_id = db.users.Find(id);
                //mymodel.userID = user_id;
                //mymodel.user  = db.users.ToList();
                return View();
                
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user  usr)
        {
            if (usr.username != null && usr.password != null)
            {
                user user = db.users.FirstOrDefault(a => a.username == usr.username && a.password == usr.password);
                if (user != null)
                {
                    Session["user"] = true;
                    Session["user"] = new user () {
                        username = usr.username,
                        password =user.password,
                        email =user.email,
                        image=user.image
                    };
                    return RedirectToAction("index", "user");
                }
                else
                {
                    Session["error_input"] = "Username ve ya password yalnisdir";
                    return RedirectToAction("login");
                }
            }
            else
            {
                Session["error_message"] = "Bosluq buraxma";
                return RedirectToAction("login");
            }

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "user");
        }

    }
}