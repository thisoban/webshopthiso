using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using ILogic;
using Microsoft.AspNetCore.CookiePolicy;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using RestSharp;
using RestSharp.Extensions;
using WebshopThiso.Models;

namespace WebshopThiso.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic = LogicFactory.LogicFactory.GUserLogic();

        public   UserViewModel GetUser(string uid)
        {
            UserViewModel user = new UserViewModel
            {
                uid = _userLogic.GetUser(uid).uid,
                Email = _userLogic.GetUser(uid).Email,
               
            };
            return user;
        }
       
        public IActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Login(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserData userlog = new UserData();
                userlog.Email = user.email;
                userlog.Passsword = user.password;
                UserData UserCondition = _userLogic.Login(userlog);
                if (UserCondition != null)
                {
                    HttpCookie myCookie = new HttpCookie();
                    DateTime now = DateTime.Now;
                    myCookie.Value = now.ToString();
                    myCookie.Expires = now.AddHours(24);
                    Response.Cookies.Append("uid", UserCondition.uid);
                    Response.Cookies.Append("admin", UserCondition.Admin.ToString());
                    return RedirectToAction("index", "Home");
                }
            }

            return View(user);
        }

        public IActionResult LogOut()
        {
            
            Response.Cookies.Delete("uid");
            Response.Cookies.Delete("admin");
            return RedirectToAction("Login");
        }
        public IActionResult Profile()
        {
            string cookie =  Request.Cookies["uid"];

            UserViewModel profileuser =  new UserViewModel()
            {
                 uid = _userLogic.GetUser(cookie).uid,
                 Email = _userLogic.GetUser(cookie).Email,
                 password = _userLogic.GetUser(cookie).Passsword,
                 Adres = _userLogic.GetUser(cookie).Adres,
                 Firstname = _userLogic.GetUser(cookie).Firstname,
                 City = _userLogic.GetUser(cookie).City,
                 
            };

            return View(profileuser);
        }

        public IActionResult ProfileEdit()
        {
            string cookies = Request.Cookies["uid"];
           UserViewModel user = new UserViewModel(_userLogic.profile(cookies));
           return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            string cookies = Request.Cookies["uid"];
            UserData UpUser = new UserData()
            {
                Email = user.Email,
                Passsword = user.password,
                Adres = user.Adres,
                City = user.City,
                Firstname = user.Firstname,
                Surname = user.Surname,
                Housenumber = user.housenumber,
                Postalcode = user.Postalcode
            };
            if (_userLogic.UpdateUser(UpUser))
            {
                return RedirectToAction("Profile");
            }

            return ProfileEdit();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel RUser)
        {
            UserData user = new UserData()
            {
                Email = RUser.Email,
                Passsword = RUser.password,
                Firstname =  RUser.Firstname,
                Surname =  RUser.Surname,
                Adres =  RUser.Adres,
                Postalcode =  RUser.Postalcode,
                City =  RUser.City,
                Housenumber = RUser.housenumber

            };
            _userLogic.Register(user);
            return View();
        }
    }
}