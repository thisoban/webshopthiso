using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DataModel;
using ILogic;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.X509;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        public bool Login(UserData user)
        {
            if (user.Email != null)
            {

            }
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool Register()
        {
            throw new NotImplementedException();
        }
        [Authorize(Roles = "admin")]
        public bool RemoveUser()
        {
            throw new NotImplementedException();
        }
    }
}
