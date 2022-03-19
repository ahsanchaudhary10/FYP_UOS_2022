using FYP_UOS_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_UOS_2022.Controllers
{
    public class PMOlinkController : Controller
    {
        Db_Entities db = new Db_Entities();
        // GET: PMOlink
        public ActionResult MakeStudentsGroups(int? id,int? classid)
        {
            if (id != null)
            {
                Session["superid"] = id;
            }
            if (classid == null)
            {
                ViewBag.msg = "Please Select Class first";
                return View(db.Students.ToList().Take(0));
            }
            ViewBag.msg = "You Select "+ db.Classes.Find(classid).Class_Name ;


            var stu = db.Students.Where(x=>x.Clas_fid==classid).ToList();
            return View(stu);
        }
        public ActionResult SelectSupervisor()
        {
            var stu = db.Supervisors.ToList();
            return View(stu);
        }
        public ActionResult SupervisorGroups()
        {
            var stu = db.Supervisors.ToList();
            return View(stu);
        }
        public ActionResult StudentsGroups(int id)
        {
            List<int> grp = db.Groups.Where(x => x.supervisor_fid == id).Select(x=>x.id).ToList();
            List<Student> stu = new List<Student>();
            foreach (var item in grp)
            {
              stu.AddRange(db.Students.Where(x => x.Group_fid == item).ToList());
            }
            return View(stu);
        }
        public ActionResult MakeGroup(string data)
        {
            int[] arraydata = new int[3];
            arraydata = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(data);
            int count = db.Groups.Count();
            count++;
            Random rnd = new Random();
            int number = rnd.Next(101, 9999);


            var stu = db.Students.FirstOrDefault(x => x.Student_id == arraydata.FirstOrDefault());
            var groupid = stu.Class.Class_Name+"-" + count + number;

            Group group = new Group();
            group.Group_id = groupid;
            group.supervisor_fid = (int)Session["superid"];
            db.Groups.Add(group);
            db.SaveChanges();

            foreach (var item in arraydata)
            {
                var s = db.Students.Find(item);
                s.Group_fid = group.id;
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();

            TempData["msg"] = " <script> ' Group Created Sucessfully ' </script> ";
            return RedirectToAction("SelectSupervisor");
        }

    }
}