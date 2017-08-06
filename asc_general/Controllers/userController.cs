using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;
using System.Net;
using System.Web.Helpers;

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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(user user)
        {
            if (user.username != null && user.password == user.password1 && user.email != null)
            {
                user usr = db.users.FirstOrDefault(u => u.email == user.email);
                if (usr == null)
                {
                    //user.password = Crypto.Hash(user.password, "MD5");
                    db.users.Add(user);
                    db.SaveChanges();


                    Session["user"] = true;
                    var response = true;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var response = false;
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            //  return View();
        }

        [HttpPost]
        public JsonResult checkEmail(string email)
        {
            if (email.Length > 0)
            {
                user user = db.users.FirstOrDefault(usr => usr.email == email);
                if (user != null)
                {
                    var response = new
                    {
                        valid = false,
                        message = "This email already exists!"
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var response = new
                    {
                        valid = true,
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = new
                {
                    valid = false,
                    message = "Email is required"
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult checkPassword(string password, string password1)
        {
            if (password==password1)
            {
                
                    var response = new
                    {
                        valid = true,
                        message = "matched"
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);               

            }
            else
            {
                var response = new
                {
                    valid = false,
                    message = "not macthed"
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

    }
}