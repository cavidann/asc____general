using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.IO;

namespace asc_general.Controllers
{
    public class CrudEducationsController : Controller
    {
        private DbAscEntities db = new DbAscEntities();

        // GET: CrudEducations
        public ActionResult Index()
        {
            var educations = db.educations.Include(e => e.edu_categories);
            return View(educations.ToList());
        }

        // GET: CrudEducations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            education education = db.educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: CrudEducations/Create
        public ActionResult Create()
        {
            ViewBag.edu_cat_id = new SelectList(db.edu_categories, "id", "name");
            return View();
        }

        // POST: CrudEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,edu_cat_id,text,photo")] education education,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if(photo.ContentType =="image/jpeg" || photo.ContentType == "image/png" || photo.ContentType == "image/gif")
                {
                    string fileName = DateTime.Now.ToString("yyyyMdHms") + Path.GetFileName(photo.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    photo.SaveAs(path);

                    education.photo = fileName;
                    db.educations.Add(education);
                    db.SaveChanges();                    
                }
                else
                {
                    ViewBag.edu_cat_id = new SelectList(db.edu_categories, "id", "name", education.edu_cat_id);
                    ViewBag.ErrorMsgForUpload = "Img format duzgun deyil";
                    return View();
                }          
                
            }
            else
            {
                ViewBag.edu_cat_id = new SelectList(db.edu_categories, "id", "name", education.edu_cat_id);
                ViewBag.ErrorMsgForUpload = "Model state is not valid";
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: CrudEducations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            education education = db.educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.edu_cat_id = new SelectList(db.edu_categories, "id", "name", education.edu_cat_id);
            return View(education);
        }

        // POST: CrudEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,edu_cat_id,text,photo")] education education, string oldfile)
        {
            var gelensekil = HttpContext.Request.Files["photo"];
            if (gelensekil.FileName.Length > 0)
            {
                if (gelensekil.ContentType == "image/jpeg" || gelensekil.ContentType == "image/png" || gelensekil.ContentType == "image/gif")
                {

                    string oldPath = Request.MapPath("~/Uploads/") + oldfile;
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }

                    string fileName = DateTime.Now.ToString("yyyyMdHms") + Path.GetFileName(gelensekil.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelensekil.SaveAs(newfile);
                    education.photo = fileName;                    
                }
                else
                {
                    ViewBag.edu_cat_id = new SelectList(db.edu_categories, "id", "name", education.edu_cat_id);
                    ViewBag.ErrorMsgForUpload = "Img format duzgun deyil";
                    return View();
                }
            }
            else
            {
                education.photo = oldfile;
            }
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(education);
        }

        // GET: CrudEducations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            education education = db.educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: CrudEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            education education = db.educations.Find(id);
            string fileName =Request.MapPath("~/Uploads/") + education.photo;
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            
            db.educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
