using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace ILogic
{
   public interface  IUserLogic
   {
        UserData Login(UserData checkuservalid);
        bool Register(UserData registerUserData);
        bool Logout();
        bool RemoveUser();
        UserData GetUser(string uid);
        UserData profile(string uid);
   }
}
