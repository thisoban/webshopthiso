using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebshopThiso.Controllers
{
    public class ProductController : Controller
    {
       private readonly ILogic.IProductLogic iproduct;
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            int id = 1;
            return View(iproduct.GetproductDetail(id));
        }
        public IActionResult ProductDelete()
        {
            return View();
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
    }
}