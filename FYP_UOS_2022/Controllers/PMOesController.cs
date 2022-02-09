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
    public class PMOesController : Controller
    {
        private Db_Entities db = new Db_Entities();

        // GET: PMOes
        public ActionResult Index()
        {
            return View(db.PMOes.ToList());
        }

        // GET: PMOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PMO pMO = db.PMOes.Find(id);
            if (pMO == null)
            {
                return HttpNotFound();
            }
            return View(pMO);
        }

        // GET: PMOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PMOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PMO_id,PMO_Name,PMO_Email,PMO_password")] PMO pMO)
        {
            if (ModelState.IsValid)
            {
                db.PMOes.Add(pMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pMO);
        }

        // GET: PMOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PMO pMO = db.PMOes.Find(id);
            if (pMO == null)
            {
                return HttpNotFound();
            }
            return View(pMO);
        }

        // POST: PMOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PMO_id,PMO_Name,PMO_Email,PMO_password")] PMO pMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pMO);
        }

        // GET: PMOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PMO pMO = db.PMOes.Find(id);
            if (pMO == null)
            {
                return HttpNotFound();
            }
            return View(pMO);
        }

        // POST: PMOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PMO pMO = db.PMOes.Find(id);
            db.PMOes.Remove(pMO);
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
