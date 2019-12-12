using System;
using System.Collections.Generic;
using System.Text;

namespace ILogic
{
   public interface  IUserLogic
   {
        bool Login();
        bool Register();
        bool Logout();
        bool RemoveUser();
   }
}
