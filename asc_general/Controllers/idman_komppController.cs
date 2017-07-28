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
    public class idman_komppController : Controller
    {
        private ascEntities db = new ascEntities();

        // GET: idman_kompp
        public ActionResult Index()
        {
            return View(db.idman_kompp.ToList());
        }

        // GET: idman_kompp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idman_kompp idman_kompp = db.idman_kompp.Find(id);
            if (idman_kompp == null)
            {
                return HttpNotFound();
            }
            return View(idman_kompp);
        }

        // GET: idman_kompp/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,photo,facebook,instagram")] idman_kompp idman_kompp, HttpPostedFileBase photo)
        {

            if (photo.ContentType == "image/jpeg" || photo.ContentType == "image/png" || photo.ContentType == "image/gif")
            {
                //double olcu = Convert.ToDouble(photo.ContentLength) / 1024.0;
                //if (olcu < 1000)
                //{
                DateTime now = DateTime.Now;

                string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(photo.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                photo.SaveAs(path);

                // cartoon cart = new cartoon();
                idman_kompp.photo = fileName;
                db.idman_kompp.Add(idman_kompp);
                db.SaveChanges();
                //}
                //else
                //{
                //    ViewBag.FileError = "Max size is 1000 kb";

                //    return Content(ViewBag.FileError);
                //}

            }
            else
            {
                ViewBag.Message = "You can only jpg,png or gif file upload";
                return View();
            }
            return RedirectToAction("Index");

        }
        // POST: idman_kompp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "id,name,photo,facebook,instagram")] idman_kompp idman_kompp)
        {
            if (ModelState.IsValid)
            {
                db.idman_kompp.Add(idman_kompp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idman_kompp);
        }

        // GET: idman_kompp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idman_kompp idman_kompp = db.idman_kompp.Find(id);
            if (idman_kompp == null)
            {
                return HttpNotFound();
            }
            return View(idman_kompp);
        }

        // POST: idman_kompp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name,photo,facebook,instagram")] idman_kompp idman_kompp, string oldfile)
        {

            var gelensekil = HttpContext.Request.Files["photo"];
            if (gelensekil.FileName.Length > 0)
            {


                if (gelensekil.ContentType == "image/jpeg" || gelensekil.ContentType == "image/png" || gelensekil.ContentType == "image/gif")
                {

                    DateTime now = DateTime.Now;

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelensekil.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelensekil.SaveAs(newfile);
                    idman_kompp.photo = fileName;


                }
                else
                {
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                idman_kompp.photo = oldfile;
            }
            if (ModelState.IsValid)
            {
                db.Entry(idman_kompp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idman_kompp);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idman_kompp idman_kompp = db.idman_kompp.Find(id);
            if (idman_kompp == null)
            {
                return HttpNotFound();
            }
            return View(idman_kompp);
        }


        // POST: idman_kompp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            idman_kompp idman_kompp = db.idman_kompp.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + idman_kompp.photo);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.idman_kompp.Remove(idman_kompp);
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
