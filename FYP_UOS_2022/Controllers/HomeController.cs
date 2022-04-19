using FYP_UOS_2022.Models;
using FYP_UOS_2022.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_UOS_2022.Controllers
{
    public class HomeController : Controller
    {
        Db_Entities db = new Db_Entities();
        public ActionResult ExamCellIndex()
        {
            return View();
        }
        public ActionResult ExamSignin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ExamSignin(Examcell ec)
        {
            var result = db.Examcells.Where(x => x.Examcell_Uniqueid == ec.Examcell_Uniqueid && x.Examcellpassword == ec.Examcellpassword).FirstOrDefault();
            if (result != null)
            {
                BaseHelper.CurrentExamCell = result;
                return RedirectToAction("ExamCellIndex");
            }
            ViewBag.error = "Invalid ID And Passowrd";
            return View();
        }
        public ActionResult Logout()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("StudentSignin");
        } 
        public ActionResult LogoutPMO()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("PMOSignin");
        } public ActionResult LogoutSuperVisor()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("SuperVisorSignin");
        } public ActionResult LogoutExam()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("ExamSignin");
        }
        public ActionResult StudentSignin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult StudentSignin(Student student)
        {
            var result = db.Students.Where(x => x.Student_Email == student.Student_Email && student.Student_Password == student.Student_Password).FirstOrDefault();
            if (result != null)
            {
                BaseHelper.CurrentStudent = result;
                return RedirectToAction("index","StudentLink");
            }
            ViewBag.error = "Invalid ID And Passowrd";
            return View();
        }
        public ActionResult PMOIndex()
        {

            return View();
        }
        public ActionResult SuperVisorIndex()
        {

            return View();
        }
        public ActionResult SupervisorSignin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SupervisorSignin(Supervisor ec)
        {
            var result = db.Supervisors.Where(x => x.Supervisor_Email == ec.Supervisor_Email && x.Supervisor_Password == ec.Supervisor_Password).FirstOrDefault();
            if (result != null)
            {
                BaseHelper.CurrentSupervisor = result;
                return RedirectToAction("SupervisorIndex");
            }
            ViewBag.error = "Invalid ID And Passowrd";
            return View();
        }
        public ActionResult PMOSignin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PMOSignin(PMO ec)
        {
            var result = db.PMOes.Where(x => x.PMO_Email == ec.PMO_Email && x.PMO_password == ec.PMO_password).FirstOrDefault();
            if (result != null)
            {
                BaseHelper.CurrentPMO = result;
                return RedirectToAction("PMOIndex");
            }
            ViewBag.error = "Invalid ID And Passowrd";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}