using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;

namespace asc_general.Controllers
{
    public class CrudEducationCategoriesController : Controller
    {
        private ascEntities db = new ascEntities();

        // GET: CrudEducationCategories
        public ActionResult Index()
        {
            return View(db.edu_categories.ToList());
        }

        // GET: CrudEducationCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_categories edu_categories = db.edu_categories.Find(id);
            if (edu_categories == null)
            {
                return HttpNotFound();
            }
            return View(edu_categories);
        }

        // GET: CrudEducationCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudEducationCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,sira")] edu_categories edu_categories)
        {
            if (ModelState.IsValid)
            {
                db.edu_categories.Add(edu_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edu_categories);
        }

        // GET: CrudEducationCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_categories edu_categories = db.edu_categories.Find(id);
            if (edu_categories == null)
            {
                return HttpNotFound();
            }
            return View(edu_categories);
        }

        // POST: CrudEducationCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sira")] edu_categories edu_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edu_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edu_categories);
        }

        // GET: CrudEducationCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_categories edu_categories = db.edu_categories.Find(id);
            if (edu_categories == null)
            {
                return HttpNotFound();
            }
            return View(edu_categories);
        }

        // POST: CrudEducationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            edu_categories edu_categories = db.edu_categories.Find(id);
            db.edu_categories.Remove(edu_categories);
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
