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
        LoginBL LoginBL = new LoginBL();
        // GET: Login
        public ActionResult Index()
        {
            return View("LoginPage");
        }
        public ActionResult GetLoginData(string username , string pwd)
        {


            var user = LoginBL.IsAuthenticated(username, pwd);
            if (user != null &&(Session["Date"]==null ||( Session["Date"] != null && (DateTime) Session["Date"] != DateTime.Today.Date)))
            {
                LoginBL.UpdateCounter(user.ID);
            }

            if (user !=null &&  user.ActionsCounter<7)
            {
                Session["FullName"] = user.FullName;
                Session["ID"] = user.ID;
                Session["ActionCounter"] = user.ActionsCounter;
                Session["Date"] = DateTime.Today.Date;
                Session["Authenticated"] = true;
                return View("HomePage");
            }
            else
            {
                Session["Authenticated"] = false;
                return RedirectToAction("Index");
            }
        }
        public ActionResult DepartmentsMenu()
        {   
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true && (int)Session["ActionCounter"] <10)
            {
                return RedirectToAction("Index", "Department");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ShiftsMenu()
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true && (int)Session["ActionCounter"] < 10)
            {
                return RedirectToAction("ShiftsMenu", "Shift");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult EmpMenu()
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true && (int)Session["ActionCounter"] < 10)
            {
                return RedirectToAction("EmployeeMenu", "Employee");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            Session["Authenticated"] = false;
            LoginBL.LogOut((int)Session["ID"], (int)Session["ActionCounter"]);
            return RedirectToAction("Index", "Login");
            
        }
    }
}