using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILogic;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebshopThiso.Models;

namespace WebshopThiso.Controllers
{
    public class ProductController : Controller
    {
       
       private ILogic.IProductLogic product = new Logic.IProductLogic();
        [Route("Product/Products")] 
        public IActionResult Products()
        {
            List<ProductViewModel> pc1 = new List<ProductViewModel>();
            ProductViewModel productje = new ProductViewModel();
            foreach (ProductData product in product.GetProducts())
            {
                productje.Name = product.Name;
                productje.Price = product.Price;
                productje.Quantity = product.Quantity;
                productje.SerialNumber = product.Serialnumber;
                pc1.Add(productje);
            }
           
          
            return View(pc1);
        }
        public IActionResult ProductDetail()
        {
            ProductViewModel productdetail = new ProductViewModel();
            int id = 1;
          
            productdetail = product.GetproductDetail(id);

            return View();
        }
        public IActionResult ProductDelete()
        {
            return View();
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}