using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace ILogic
{
   public interface  IUserLogic
   {
        bool Login(UserData checkuservalid);
        bool Register(UserData registerUserData);
        bool Logout();
        bool RemoveUser();
   }
}
