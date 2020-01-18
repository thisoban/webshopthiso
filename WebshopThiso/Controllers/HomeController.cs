using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Hanssens.Net;
using WebshopThiso.Models;

namespace WebshopThiso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static string GetUidFromLocatStorage()
        {
            string uid = null;
            if (String.IsNullOrEmpty(new LocalStorage().Get("uid").ToString()))
            {
                uid = new LocalStorage().Get("uid").ToString();
            }
            else
            {
                uid = "";
            }
            
            return uid;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.admin = Request.Cookies["admin"];
            ViewBag.uid = Request.Cookies["uid"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
