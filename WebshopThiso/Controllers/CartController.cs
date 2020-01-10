using System.Collections.Generic;
using System.Linq;
using ILogic;
using LogicFactory;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using WebshopThiso.Helper;
using WebshopThiso.Models;

namespace WebshopThiso.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly ICartLogic _cartLogic = LogicFactory.LogicFactory.GCartLogic();
           [Route("index")]
        
        public IActionResult Index( IProductLogic iproductlogic)
        {
            string cookie = Request.Cookies["cartitems"];
            Dictionary<int, int> winkelmandje = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
            List<ProductData> allproducts = iproductlogic.GetProducts().ToList();
            List<ProductData> CartProducts = new List<ProductData>();
            foreach ((int key, int value) in winkelmandje)
            {
                CartProducts = allproducts.Where(product => product.Id == key).ToList();
            }
            return View(CartProducts);
            //var cart = SessionHelper.GetObjectFromJson<List<ProductViewModel>>(HttpContext.Session, "cart");
            //ViewBag.cart = cart;
            //ViewBag.total = cart.Sum(item => item.Price * item.Quantity);
            //return View();
        }
       [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            ProductViewModel productModel = new ProductViewModel();
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();

                //cart.Add(new CartItem { Product = productModel.find();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    //cart.Add(new CartItem { Product = productModel.find(serialnumber), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int IsExist(string id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.SerialNumber.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}