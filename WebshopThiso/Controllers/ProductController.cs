using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using WebshopThiso.Models;
using IProductLogic = ILogic.IProductLogic;

namespace WebshopThiso.Controllers
{
    public class ProductController : Controller
    {
       
       private readonly IProductLogic product = new Logic.IProductLogic();
        [Route("Product/Products")] 
        public IActionResult Products()
        {
            var pc1 = new List<ProductViewModel>();
            var productje = new ProductViewModel();
            foreach (var product in product.GetProducts())
            {
                productje.Name = product.Name;
                productje.Price = product.Price;
                productje.Quantity = product.Quantity;
                productje.SerialNumber = product.Serialnumber;
                pc1.Add(productje);
            }
           
          
            return View(pc1);
        }

        public IActionResult Detail()
        {
            int id = 6;

            return View(product.GetproductDetail(id));
        }
        public IActionResult ProductDelete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel productnew)
        {
            var newProduct = new ProductData();
            newProduct.Name = productnew.Name;
            newProduct.Description = productnew.Description;
            newProduct.Quantity = productnew.Quantity;
            newProduct.Price = productnew.Price;

            product.AddProduct(newProduct);
            return RedirectToAction("products");
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}