﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Asp.Net.Models;
namespace Project_Asp.Net.Controllers
{
    public class ShiftController : Controller
    {
        ShiftBL shiftBL = new ShiftBL();
        // GET: Shift
        public ActionResult ShiftsMenu()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                var result = shiftBL.GetShiftData();
                ViewBag.shiftsData = result;
                return View("ShiftsPage");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult EditEmp(int id1)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                return RedirectToAction("GetDataEditEmp", "Employee",new {id =id1});
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GetShiftFromUser()
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(1))
            {
                return View("GetShiftData");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AddShift(shift sh)
        {
            if (Session["UserBL"] != null && ((UserBL)Session["UserBL"]).CheckActionCounter(0))
            {
                shiftBL.Add(sh);
                return RedirectToAction("ShiftsMenu");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }

    }
}