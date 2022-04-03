using FYP_UOS_2022.Models;
using FYP_UOS_2022.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_UOS_2022.Controllers
{
    public class StudentLinkController : Controller
    {
        Db_Entities db = new Db_Entities();
        // GET: StudentLink
        public ActionResult StudentsTask()
        {
            var tasks = db.Task_Assign.Where(x => x.Group_fid == BaseHelper.CurrentStudent.Group_fid).ToList();
            return View(tasks);
        }
        public ActionResult index()
        {
            
            return View();
        }
        public ActionResult taskform(int id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult taskform(HttpPostedFileBase task_file,int fid)
        {
            var taskData = new Task_Data();

            task_file.SaveAs(Server.MapPath("~/content/taskdata/" + task_file.FileName));

            taskData.Submit_Date = System.DateTime.Now;
            taskData.Taskassign_fid = fid;
            taskData.TaskData = "~/content/taskdata/" + task_file.FileName;
            db.Task_Data.Add(taskData);
            db.SaveChanges();
            return RedirectToAction("studentstask");
        }
    }
}