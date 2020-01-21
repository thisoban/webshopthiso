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

        
        [Route("Product/ProductsList")]
       
        public IActionResult ProductList()
        {
            var ListProducts = new List<ProductViewModel>();
           
            foreach (var product in product.GetProducts())
            {
                var products = new ProductViewModel( product.Name, product.Price, product.Description, product.Quantity, product.Serialnumber);
                ListProducts.Add(products);
            }
           
          
            return View(ListProducts);
        }
        [Route("Product/Products")]
        public IActionResult products(ProductViewModel viewproducts)
        {
            ViewBag.admin = Request.Cookies["admin"];
            ViewBag.uid = Request.Cookies["uid"];
            List<ProductViewModel>products = new List<ProductViewModel>();
            
            foreach (var listproduct in product.GetProducts())
            {
                ProductViewModel webProduct = new ProductViewModel();
                webProduct.Name = listproduct.Name;
                webProduct.Description = listproduct.Description;
                webProduct.Price = listproduct.Price;
                webProduct.Quantity = listproduct.Quantity;
                webProduct.SerialNumber = listproduct.Serialnumber;
                products.Add(webProduct);
            }
            return View(products);
        }
        public IActionResult Detail()
        {
            ViewBag.admin = Request.Cookies["admin"];
            ViewBag.uid = Request.Cookies["uid"];
            int id = 234567890;

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