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
        private readonly IDalUser user = DalFactory.DalFactory.GUserDAl();
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

        public bool Register(UserData user)
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
