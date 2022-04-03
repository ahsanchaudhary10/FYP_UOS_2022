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
    public class Student_TaskController : Controller
    {
        private Db_Entities db = new Db_Entities();

        // GET: Student_Task
        public ActionResult Index()
        {
            var student_Task = db.Student_Task.Include(s => s.Task_Assign1);
            return View(student_Task.ToList());
        }

        // GET: Student_Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Task student_Task = db.Student_Task.Find(id);
            if (student_Task == null)
            {
                return HttpNotFound();
            }
            return View(student_Task);
        }

        // GET: Student_Task/Create
        public ActionResult Create()
        {
            ViewBag.Task_id = new SelectList(db.Task_Assign, "id", "id");
            return View();
        }

        // POST: Student_Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_id,Task_Name,Task_start_date,Task_end_Date,Task_status")] Student_Task student_Task)
        {
            if (ModelState.IsValid)
            {
                db.Student_Task.Add(student_Task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Task_id = new SelectList(db.Task_Assign, "id", "id", student_Task.Task_id);
            return View(student_Task);
        }

        // GET: Student_Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Task student_Task = db.Student_Task.Find(id);
            if (student_Task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Task_id = new SelectList(db.Task_Assign, "id", "id", student_Task.Task_id);
            return View(student_Task);
        }

        // POST: Student_Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_id,Task_Name,Task_start_date,Task_end_Date,Task_status")] Student_Task student_Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Task_id = new SelectList(db.Task_Assign, "id", "id", student_Task.Task_id);
            return View(student_Task);
        }

        // GET: Student_Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Task student_Task = db.Student_Task.Find(id);
            if (student_Task == null)
            {
                return HttpNotFound();
            }
            return View(student_Task);
        }

        // POST: Student_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Task student_Task = db.Student_Task.Find(id);
            db.Student_Task.Remove(student_Task);
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
