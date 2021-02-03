using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Asp.Net.Models
{
    public class UserBL
    {

        public  user user;
        private int  limitAction = 15 ;
        factoryDBEntities db = new factoryDBEntities();
        
        public UserBL(user user2)
        {
            user = user2;
        }
        public bool CheckActionCounter()
        {
           CheckDate();
           if(user.ActionsCounter < limitAction)
            {
                
                user.ActionsCounter= user.ActionsCounter+1;
                HttpContext.Current.Session["ActionCounter"] = user.ActionsCounter;
                UpDateUserData();
                return true;
            }
           else
            {
                return false;
            }
        }
        
        public void CheckDate ()
        {
            if(user.LastSeen==null || (user.LastSeen!=null && user.LastSeen!= DateTime.Today))
            {
                user.ActionsCounter = 0;
                user.LastSeen = DateTime.Today;
            }
        }
        public void UpDateUserData()
        {
           var result= db.users.Where(x => x.ID == user.ID).First();
            result.ActionsCounter = user.ActionsCounter;
            result.LastSeen = DateTime.Today;
            db.SaveChanges();
        }


    }
}