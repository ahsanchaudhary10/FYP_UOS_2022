using FYP_UOS_2022.Models;
using FYP_UOS_2022.Utills;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_UOS_2022.Controllers
{
    public class HomeController : Controller
    {
        Db_Entities db = new Db_Entities();
        public ActionResult IndexUser()
        {
            return View();
        } 
        public ActionResult aboutus()
        {
            return View();
        }

        public ActionResult NewPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(string password)
        {
            var userEmail = (string)Session["userforgetPassword"];
            if (userEmail == null)
            {
                TempData["error"] = "Email is Invalid or Not Available";
                return RedirectToAction("customerlogin");
            }
            string type = (string)Session["type"];
            if (type == "Student")
            {
                var updaetStudent = db.Students.Where(x => x.Student_Email == userEmail).FirstOrDefault();
                updaetStudent.Student_Password = password;
                db.Entry(updaetStudent).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            else if(type == "PMO")
            {
                var UpdatePMO = db.PMOes.Where(x => x.PMO_Email == userEmail).FirstOrDefault();
                UpdatePMO.PMO_password = password;
                db.Entry(UpdatePMO).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if(type == "Supervisor")
            {
                var updateSuper = db.Supervisors.Where(x => x.Supervisor_Email == userEmail).FirstOrDefault();
                updateSuper.Supervisor_Password = password;
                db.Entry(updateSuper).State = EntityState.Modified;
                db.SaveChanges();
            }
                TempData["msg"] = "Password Updated Successfully";
            return RedirectToAction("indexuser");

        }
        public ActionResult CodeVerify()
        {


            return View();
        }
        [HttpPost]
        public ActionResult CodeVerify(int code)
        {
            int sendCode = (int)Session["code"];
            if (code == sendCode)
            {
                return RedirectToAction("NewPassword");

            }
            TempData["error"] = "Invalid Code";
            return View();
        }
        [HttpPost]
        public ActionResult FrogetPassword(string email , string type)
        {
            if (type == "Student")
            {
                var student = db.Students.Where(x => x.Student_Email == email).FirstOrDefault();
                if (student == null)
                {
                    TempData["error"] = "Invalid Email";
                    return RedirectToAction("CustomerLogin");
                }
                Session["userforgetPassword"] = student.Student_Email;

            }
           else if (type == "PMO")
            {
                var PMO = db.PMOes.Where(x => x.PMO_Email == email).FirstOrDefault();
                if (PMO == null)
                {
                    TempData["error"] = "Invalid Email";
                    return RedirectToAction("CustomerLogin");
                }
                Session["userforgetPassword"] = PMO.PMO_Email;
                
            }
             else if (type == "Supervisor")
            {
                var Supervisor = db.Supervisors.Where(x => x.Supervisor_Email == email).FirstOrDefault();
                if (Supervisor == null)
                {
                    TempData["error"] = "Invalid Email";
                    return RedirectToAction("CustomerLogin");
                }
                Session["userforgetPassword"] = Supervisor.Supervisor_Email;
            }
            else
            {
                return RedirectToAction("indexuser");

            }


            Random random = new Random();
            int Code = random.Next(1001, 9999);
            Session["code"] = Code;
            string useremail = (string)Session["userforgetPassword"];

            Utill.SendEmailForForgotPassword(useremail, Code);
            Session["type"] = type;
            return RedirectToAction("CodeVerify");
        }





        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult Signin(string Email,string password, string type )
        {
            if (type == "Exam")
            {
                var result = db.Examcells.Where(x => x.Examcell_Uniqueid == Email && x.Examcellpassword == password).FirstOrDefault();
                if (result != null)
                {
                    BaseHelper.CurrentExamCell = result;
                    return RedirectToAction("ExamCellIndex");
                }
                TempData["error"] = "Invalid ID And Passowrd";
                return RedirectToAction("IndexUser");
            }
            else if (type == "Supervisor")
            {
                var result = db.Supervisors.Where(x => x.Supervisor_Email == Email && x.Supervisor_Password == password).FirstOrDefault();
                if (result != null)
                {
                    BaseHelper.CurrentSupervisor = result;
                    return RedirectToAction("SupervisorIndex");
                }

                TempData["error"] = "Invalid ID And Passowrd";
                return RedirectToAction("IndexUser");

            }
            else if (type == "PMO")
            {
                var result = db.PMOes.Where(x => x.PMO_Email == Email && x.PMO_password == password).FirstOrDefault();
                if (result != null)
                {
                    BaseHelper.CurrentPMO = result;
                    return RedirectToAction("PMOIndex");
                }

                TempData["error"] = "Invalid ID And Passowrd";
                return RedirectToAction("IndexUser");
            }
            else if (type == "Student")
            {
                var result = db.Students.Where(x => x.Student_Email == Email && x.Student_Password == password).FirstOrDefault();
                if (result != null)
                {
                    BaseHelper.CurrentStudent = result;
                    return RedirectToAction("index", "StudentLink");
                }
                TempData["error"] = "Invalid ID And Passowrd";
                return RedirectToAction("IndexUser");
            }

            


            return RedirectToAction("IndexUser");
        }
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
            return RedirectToAction("IndexUser");
        } 
        public ActionResult LogoutPMO()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("IndexUser");
        } public ActionResult LogoutSuperVisor()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("IndexUser");
        } public ActionResult LogoutExam()
        {
            BaseHelper.CurrentExamCell = null;
            BaseHelper.CurrentStudent = null;
            BaseHelper.CurrentPMO = null;
            BaseHelper.CurrentSupervisor = null;
            return RedirectToAction("IndexUser");
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