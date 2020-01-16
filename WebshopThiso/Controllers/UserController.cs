using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Hanssens.Net;
using ILogic;
using Microsoft.AspNetCore.Mvc;
using WebshopThiso.Models;

namespace WebshopThiso.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic = LogicFactory.LogicFactory.GUserLogic();

       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            UserData userlog = new UserData();
            userlog.Email = user.Email;
            userlog.Passsword = user.password;
            if (_userLogic.Login(userlog))
            {
                var storage = new LocalStorage();
                storage.Store("uid", userlog.uid);
                storage.Persist();
                return RedirectToAction("index", "Home");
            }

            return View(_userLogic.Login(userlog));
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}