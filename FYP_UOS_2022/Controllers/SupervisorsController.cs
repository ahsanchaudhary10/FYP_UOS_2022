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
    public class SupervisorsController : Controller
    {
        private Db_Entities db = new Db_Entities();

        // GET: Supervisors
        public ActionResult Index()
        {
            var supervisors = db.Supervisors.Include(s => s.PMO);
            return View(supervisors.ToList());
        }

        // GET: Supervisors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        // GET: Supervisors/Create
        public ActionResult Create()
        {
            ViewBag.PMO_FID = new SelectList(db.PMOes, "PMO_id", "PMO_Name");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supervisor_id,Supervisor_Name,Supervisor_Email,Supervisor_Password,PMO_FID")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Supervisors.Add(supervisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PMO_FID = new SelectList(db.PMOes, "PMO_id", "PMO_Name", supervisor.PMO_FID);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PMO_FID = new SelectList(db.PMOes, "PMO_id", "PMO_Name", supervisor.PMO_FID);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supervisor_id,Supervisor_Name,Supervisor_Email,Supervisor_Password,PMO_FID")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PMO_FID = new SelectList(db.PMOes, "PMO_id", "PMO_Name", supervisor.PMO_FID);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            db.Supervisors.Remove(supervisor);
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
