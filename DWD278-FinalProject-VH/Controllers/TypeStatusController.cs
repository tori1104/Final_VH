using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DWD278_FinalProject_VH.Models;

namespace DWD278_FinalProject_VH.Controllers
{
    public class TypeStatusController : Controller
    {
        private ToWatchListContext db = new ToWatchListContext();

        // GET: TypeStatus
        public ActionResult Index()
        {
            return View(db.TypeStatus.ToList());
        }

        // GET: TypeStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeStatus typeStatus = db.TypeStatus.Find(id);
            if (typeStatus == null)
            {
                return HttpNotFound();
            }
            return View(typeStatus);
        }

        // GET: TypeStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] TypeStatus typeStatus)
        {
            if (ModelState.IsValid)
            {
                db.TypeStatus.Add(typeStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeStatus);
        }

        // GET: TypeStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeStatus typeStatus = db.TypeStatus.Find(id);
            if (typeStatus == null)
            {
                return HttpNotFound();
            }
            return View(typeStatus);
        }

        // POST: TypeStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] TypeStatus typeStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeStatus);
        }

        // GET: TypeStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeStatus typeStatus = db.TypeStatus.Find(id);
            if (typeStatus == null)
            {
                return HttpNotFound();
            }
            return View(typeStatus);
        }

        // POST: TypeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeStatus typeStatus = db.TypeStatus.Find(id);
            db.TypeStatus.Remove(typeStatus);
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
