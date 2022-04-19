using FYP_UOS_2022.Models;
using FYP_UOS_2022.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_UOS_2022.Controllers
{
    public class SupervisorLinkController : Controller
    {
        Db_Entities db = new Db_Entities(); 
        // GET: SupervisorLink
        public ActionResult StudentGroups()
        {
            var group = db.Groups.Where(x => x.supervisor_fid == BaseHelper.CurrentSupervisor.Supervisor_id).ToList();
            return View(group);
        }
        public ActionResult GroupDetail(int id)
        {
          var students=  db.Students.Where(x => x.Group_fid == id).ToList();
            return View(students);
        }
        public ActionResult AssignTask(int id)
        {
           var task= db.Student_Task.Find(id);
            return View(task);
        }
        public ActionResult AssigntasktoStudent(int id,int taskid)
        {
          
              var groupids =  db.Classes.Find(id).Students.Where(x=>x.Group_fid!=null).GroupBy(x => x.Group_fid).Select(x => x.FirstOrDefault().Group_fid).ToList();
            List<int?> unAssignId = new List<int?>();
            foreach (var item in groupids)
            {
                var isAssign=  db.Task_Assign.Any(x => x.Group_fid == item && x.Task_fid == taskid);
                if (!isAssign)
                {
                    unAssignId.Add(item);
                }

            }
            if (unAssignId.Count() < 1)
            {
                TempData["msg"] = " ' All Groups All ready Assigned Sucessfully '  ";

                return RedirectToAction("AssignTask", "SuperVisorLink",new { id=taskid});

            }
            foreach (var item in unAssignId)
            {
                var taskAssign = new Task_Assign();

                taskAssign.Task_fid = taskid;
                taskAssign.Group_fid =(int)item;
                taskAssign.Assign_Date = DateTime.Now;
                db.Task_Assign.Add(taskAssign);
                
            db.SaveChanges();

            }
            TempData["msg"] = " <script>  alert( ' Assign Task Sucessfully ') </script> ";
            return RedirectToAction("index","Student_Task");
        }
    }
}