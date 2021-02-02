using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Asp.Net.Models
{
    public class ShiftAndEmp
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public System.DateTime ShiftDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }



    }
}