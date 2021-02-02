using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Asp.Net.Models
{
    public class DepartmentHelper
    {

        public string DepName { get;set;}
        public int ID { get;set;}
        public int  Manager { get;set;}
        public string EmpId { get;set;}
        public string EmpName { get;set;}
        public override bool Equals(object obj)
        {
            return this.DepName.Equals(((DepartmentHelper)obj).DepName)&& this.Manager.Equals(((DepartmentHelper)obj).Manager)&& this.EmpId.Equals(((DepartmentHelper)obj).EmpId)&&this.ID.Equals(((DepartmentHelper)obj).ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}