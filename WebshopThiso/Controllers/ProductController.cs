using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using ILogic;
using WebshopThiso.Models;


namespace WebshopThiso.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductLogic product = LogicFactory.LogicFactory.GProductLogic();
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
        [HttpGet]
        public IActionResult ProductDelete()
        {
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel productnew)
        {
            var newProduct = new ProductData(productnew.Name, productnew.Description, productnew.Price,
                productnew.Quantity, productnew.SerialNumber);

            product.AddProduct(newProduct);
            return RedirectToAction("products");
        }
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int serialNumber)
        {
         
            ProductViewModel editproduct = new ProductViewModel(product.GetproductDetail(serialNumber));
            return View(editproduct);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel upProduct)
        {
            ProductData updateProductData= new ProductData()
            {
                Name = upProduct.Name,
                Price = upProduct.Price,
                Description = upProduct.Description,
                Quantity = upProduct.Quantity,
                Serialnumber = upProduct.SerialNumber
            };
            product.UpdateProduct(updateProductData);
            return RedirectToAction("Products");
        }
    }
}