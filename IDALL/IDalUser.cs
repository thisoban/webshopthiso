﻿using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace IDAL
{
    public interface IDalUser
    {
        bool InsertUser(UserData newUser);
        UserData GetUserByEmail(UserData data);
        List<UserData> GetUsers();
        bool UpdateCustomer(UserData data);
        bool DeleteUser(UserData data);
        UserData GetuserdetailFromUid(string uid);
        bool UpdateUser(UserData data);

    }
}
