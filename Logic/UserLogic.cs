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
        private readonly IDalUser _userDal = DalFactory.DalFactory.GUserDAl();
        public UserData Login(UserData user)
        {
            UserData loginUserData = new UserData();
          
            if (user.Email != null)
            {
                if (user.Email == _userDal.GetUserByEmail(user).Email)
                {
                    if (user.Passsword == _userDal.GetUserByEmail(user).Passsword)
                    {
                        loginUserData = _userDal.GetUserByEmail(user);
                    }
                }
            }
            return loginUserData;
        }

        public UserData profile(string uid)
        {
            UserData profile = _userDal.GetuserdetailFromUid(uid);
            return profile;
        }
        public bool Logout()
        {

            throw new NotImplementedException();
        }

        public bool Register(UserData user)
        {
            return (_userDal.InsertUser(user));
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

        public bool UpdateUser(UserData data)
        {
            if (_userDal.UpdateUser(data))
            {
                return true;
            }

            return false;
        }
        public  UserData GetUser(string uid) => _userDal.GetuserdetailFromUid(uid);
    }
}
