using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Asp.Net.Models;
namespace Project_Asp.Net.Controllers
{
    public class LoginController : Controller
    {
        LoginBL LoginBL = new LoginBL();        // GET: Login
        public ActionResult Index()
        {
            return View("LoginPage");
        }
        public ActionResult GetLoginData(string username , string pwd)
        {
            var user = LoginBL.IsAuthenticated(username, pwd);
            if (user !=null)
            {
                UserBL userBL = new UserBL(user);
                Session["UserBL"] = userBL;
                if (userBL.CheckActionCounter())
                {
                    Session["FullName"] = user.FullName;
                    Session["ActionCounter"] = user.ActionsCounter;
                    return View("HomePage");
                }
            }
               return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            if (Session["UserBL"] !=null && ((UserBL)Session["UserBL"]).CheckActionCounter())
            {
                return View("HomePage");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult DepartmentsMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter())
            {
                ((UserBL)Session["UserBL"]).user.ActionsCounter--;
                return RedirectToAction("Index", "Department");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ShiftsMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter())
            {
                ((UserBL)Session["UserBL"]).user.ActionsCounter--;
                return RedirectToAction("ShiftsMenu", "Shift");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult EmpMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter())
            {
                ((UserBL)Session["UserBL"]).user.ActionsCounter--;
                return RedirectToAction("EmployeeMenu", "Employee");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            ((UserBL)Session["UserBL"]).UpDateUserData();
            Session.Clear();
            return RedirectToAction("Index", "Login");
            
        }
    }
}