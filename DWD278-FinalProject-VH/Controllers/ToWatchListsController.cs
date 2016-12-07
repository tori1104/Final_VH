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
    public class ToWatchListsController : Controller
    {
        private ToWatchListContext db = new ToWatchListContext();

        // GET: ToWatchLists
        public ActionResult Index()
        {
            var toWatchList = db.ToWatchList.Include(t => t.Genre).Include(t => t.Rating).Include(t => t.TypeStatus);
            return View(toWatchList.ToList());
        }

    

        // GET: ToWatchLists/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genre, "ID", "Description");
            ViewBag.RatingID = new SelectList(db.Rating, "ID", "Description");
            ViewBag.TypeStatusID = new SelectList(db.TypeStatus, "ID", "Description");
            return View();
        }

        // POST: ToWatchLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Year,GenreID,RatingID,Description,TypeStatusID")] ToWatchList toWatchList)
        {
            if (ModelState.IsValid)
            {
                db.ToWatchList.Add(toWatchList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genre, "ID", "Description", toWatchList.GenreID);
            ViewBag.RatingID = new SelectList(db.Rating, "ID", "Description", toWatchList.RatingID);
            ViewBag.TypeStatusID = new SelectList(db.TypeStatus, "ID", "Description", toWatchList.TypeStatusID);
            return View(toWatchList);
        }

        // GET: ToWatchLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToWatchList toWatchList = db.ToWatchList.Find(id);
            if (toWatchList == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genre, "ID", "Description", toWatchList.GenreID);
            ViewBag.RatingID = new SelectList(db.Rating, "ID", "Description", toWatchList.RatingID);
            ViewBag.TypeStatusID = new SelectList(db.TypeStatus, "ID", "Description", toWatchList.TypeStatusID);
            return View(toWatchList);
        }

        // POST: ToWatchLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,GenreID,RatingID,Description,TypeStatusID")] ToWatchList toWatchList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toWatchList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genre, "ID", "Description", toWatchList.GenreID);
            ViewBag.RatingID = new SelectList(db.Rating, "ID", "Description", toWatchList.RatingID);
            ViewBag.TypeStatusID = new SelectList(db.TypeStatus, "ID", "Description", toWatchList.TypeStatusID);
            return View(toWatchList);
        }

        // GET: ToWatchLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToWatchList toWatchList = db.ToWatchList.Find(id);
            if (toWatchList == null)
            {
                return HttpNotFound();
            }
            return View(toWatchList);
        }

        // POST: ToWatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToWatchList toWatchList = db.ToWatchList.Find(id);
            db.ToWatchList.Remove(toWatchList);
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
