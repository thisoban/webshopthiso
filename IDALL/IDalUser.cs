using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace IDAL
{
    public interface IDalUser
    {
        bool InsertUser(UserData newUser);
        UserData GetUserDetail(int id);
        List<UserData> GetUsers();
        bool UpdateUser();
        bool DeleteUser();
        
    }
}
