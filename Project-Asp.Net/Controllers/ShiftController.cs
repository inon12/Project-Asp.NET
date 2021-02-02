using System;
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
            var result = shiftBL.GetShiftData();
            ViewBag.shiftsData = result;
            return View("ShiftsPage");
        }
        public ActionResult EditEmp(int id1)
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true)
            {
                return RedirectToAction("GetDataEditEmp", "Employee",new {id =id1});
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GetShiftFromUser()
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true && (int)Session["ActionCounter"] < 10)
            {
                return View("GetShiftData");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AddShift(shift sh)
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"] == true && (int)Session["ActionCounter"] < 10)
            {
                shiftBL.Add(sh);
                return RedirectToAction("ShiftsMenu");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}