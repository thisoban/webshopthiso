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
           
            foreach (var product in product.GetProducts())
            {
                var productje = new ProductViewModel( product.Name, product.Price, product.Description, product.Quantity, product.Serialnumber);
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
            ProductData newProduct = new ProductData( productnew.Name, productnew.Description, productnew.Price, productnew.Quantity, productnew.SerialNumber );

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