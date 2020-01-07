using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace IDAL
{
    public interface IDalUser
    {
        bool InsertUser(UserData newUser);
        UserData GetUserDetail(UserData data);
        List<UserData> GetUsers();
        bool UpdateUser(UserData data);
        bool DeleteUser(UserData data);
        
    }
}
