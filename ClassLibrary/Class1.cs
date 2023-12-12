using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UserTest
    {
        public static bool ValidatedUser(string Login, string Password)
        {
            if(Login == null || Password == null) 
                return false;
           else if(Password == "65603" && Login == "feofan2003") return true;
           else return false;
        }
        public static bool ValidateBack(bool click)
        {
            if (click == true)
            {
                return true;
            }
            return false;
        }
    }
}
