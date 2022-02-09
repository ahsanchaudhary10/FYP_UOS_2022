using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYP_UOS_2022.Models;

namespace FYP_UOS_2022.Controllers
{
    public class ExamcellsController : Controller
    {
        private Db_Entities db = new Db_Entities();

        // GET: Examcells
        public ActionResult Index()
        {
            return View(db.Examcells.ToList());
        }

        // GET: Examcells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examcell examcell = db.Examcells.Find(id);
            if (examcell == null)
            {
                return HttpNotFound();
            }
            return View(examcell);
        }

        // GET: Examcells/Create
        public ActionResult Create()
        {
            int count=db.Examcells.Count();
            count++;
            Random rnd = new Random();
            int number = rnd.Next(101, 9999);

            Examcell examcell = new Examcell();
            examcell.Examcell_Uniqueid = "EX-Cell-" + count+number;
            return View(examcell);
        }

        // POST: Examcells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Examcell_id,Examcell_Uniqueid,Examcellpassword,Examcell_Email")] Examcell examcell)
        {
            if (ModelState.IsValid)
            {
                db.Examcells.Add(examcell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examcell);
        }

        // GET: Examcells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examcell examcell = db.Examcells.Find(id);
            if (examcell == null)
            {
                return HttpNotFound();
            }
            return View(examcell);
        }

        // POST: Examcells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Examcell_id,Examcell_Uniqueid,Examcellpassword,Examcell_Email")] Examcell examcell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examcell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examcell);
        }

        // GET: Examcells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examcell examcell = db.Examcells.Find(id);
            if (examcell == null)
            {
                return HttpNotFound();
            }
            return View(examcell);
        }

        // POST: Examcells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examcell examcell = db.Examcells.Find(id);
            db.Examcells.Remove(examcell);
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
