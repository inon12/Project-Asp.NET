using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Asp.Net.Models
{
    public class LoginBL
    {
         factoryDBEntities db = new factoryDBEntities();
        
        public user IsAuthenticated (string username , string pwd)
        {
            var result = db.users.Where(x => x.UserName == username && x.Pwd == pwd);
            if(result.Count() != 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        } 
    }
}