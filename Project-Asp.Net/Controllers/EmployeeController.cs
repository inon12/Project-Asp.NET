
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Asp.Net.Models;

namespace Project_Asp.Net.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBL EmployeeBL = new EmployeeBL();
        // GET: Employee
        public ActionResult EmployeeMenu()
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = EmployeeBL.EmployeeList();
                ViewBag.EmpData = result;
                return View("Employees");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
       
        
        public ActionResult GetDataEditEmp(int id)
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = EmployeeBL.GetEmployee(id);
                var dep = EmployeeBL.GetDepartments();
                ViewBag.Departments = dep;

                return View("GetEmloyeeDataFromUser",result);
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult UpdateEmp(employee emp)
        {

            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                EmployeeBL.UpdateEmp(emp);
                return RedirectToAction("EmployeeMenu");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        
            public ActionResult AddShiftToEmployee(int id)
            {

                if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                {
                    EmployeeShift emp =new EmployeeShift();
                    emp.EmployeeID = id;
                        return View("GetEmpShiftData",emp);
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Index", "Login");
                }
            }

            public ActionResult AddShiftEmp(EmployeeShift emp)
            {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
               {
                    EmployeeBL.AddShift(emp);
                    return RedirectToAction("EmployeeMenu");
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Index", "Login");
                }
             }
            public ActionResult DelEmp(int id)
            {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                     EmployeeBL.Remove(id);
                     return RedirectToAction("EmployeeMenu");
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Index", "Login");
                }
            }
            [HttpGet]
            public ActionResult SearchEmp(string text)
            {
                if (Session["UserBL"] !=null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
                    {
                         var result= EmployeeBL.SearchEmp(text);
                         ViewBag.EmpData = result;
                         return View("ResultSearchEmployee");
                    }
                    else
                    {
                        Session.Clear();
                        return RedirectToAction("Index", "Login");
                    }
             }

    }
}