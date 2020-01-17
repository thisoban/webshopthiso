using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DataModel;
using IDAL;
using ILogic;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.X509;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IDalUser userDal = DalFactory.DalFactory.GUserDAl();
        public UserData Login(UserData user)
        {
            UserData loginUserData = new UserData();
          
            if (user.Email != null)
            {
                if (user.Email == userDal.GetUserDetail(user).Email)
                {
                    if (user.Passsword == userDal.GetUserDetail(user).Passsword)
                    {
                        loginUserData = userDal.GetUserDetail(user);
                    }
                }
            }
            return loginUserData;
        }

        public bool Logout()
        {

            throw new NotImplementedException();
        }

        public bool Register(UserData user)
        {
            
            throw new NotImplementedException();
        }
        [Authorize(Roles = "admin")]
        public bool RemoveUser()
        {
            throw new NotImplementedException();
        }

        private bool IsAdmin(UserData user)
        {
            bool userRole = user.Admin;

            return userRole;
        }

        public  UserData GetUser(string uid) => userDal.GetuserdetailFromUid(uid);
    }
}
