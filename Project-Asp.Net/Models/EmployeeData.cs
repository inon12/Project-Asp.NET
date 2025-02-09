﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Asp.Net.Models
{
    public class EmployeeData
    {

        public int ID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public int StartWorkYear { get; set; }
        public List<ShiftAndEmp> Shifts { get; set; }
    }
}