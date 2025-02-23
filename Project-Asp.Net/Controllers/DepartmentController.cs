﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Asp.Net.Models;

namespace Project_Asp.Net.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL DepartmentBL = new DepartmentBL();
        // GET: Department
        
          
        public ActionResult Index()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var departments = DepartmentBL.GetDepartmentsData();
                ViewBag.departments = departments;
                return View("DepartmentPage");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GetDepartment(int id)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var deparment = DepartmentBL.GetDepartmentData(id);
                var emp = DepartmentBL.GetEmpData();
                ViewBag.emp = emp;
                return View("EditDepartment", deparment);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult UpdateDep(department dep)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                DepartmentBL.Update(dep);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult DeleteDep(department dep)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                DepartmentBL.Delete(dep);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GetDepartmentDataFromUser()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var emp = DepartmentBL.GetEmpData();
                ViewBag.emp = emp;
                return View("GetDepartmentData");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        
            public ActionResult AddDep(department dep)
            {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                    DepartmentBL.Add(dep);
                    return RedirectToAction("Index");
                 }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
    }
}