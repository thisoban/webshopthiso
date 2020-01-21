using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using ILogic;
using LogicFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly IProductLogic _productlogic = LogicFactory.LogicFactory.GProductLogic();
           [Route("index")]
        
        public IActionResult Index( )
        {
            ViewBag.admin = Request.Cookies["admin"];
            ViewBag.uid = Request.Cookies["uid"];
            string cookie = Request.Cookies["cartitems"];
            if (cookie != null)
            {
                Dictionary<int, int> winkelmandje = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
                List<ProductData> allproducts = _productlogic.GetProducts().ToList();
                List<CartItem> CartProducts = new List<CartItem>();
                foreach ((int key, int value) in winkelmandje)
                {
                    foreach (ProductData data in allproducts.Where(product => product.Serialnumber == key).ToList())
                    {
                        CartItem item = new CartItem
                        {
                            Product = new ProductViewModel
                            {
                                SerialNumber = data.Serialnumber,
                                Price =  data.Price,
                                Name =  data.Name
                            },
                            Quantity = value
                        };
                        CartProducts.Add(item);
                    }
                    
                }
                
                return View(CartProducts);
            }

            return View();
        }
        [ Route("CartAdd")]
        public IActionResult CartAdd(int serialnumber, int quantity)
        {
            string cookie = Request.Cookies["CartItems"];

            if (cookie != null)
            {
                Dictionary<int, int> artikeldictionary = new Dictionary<int, int>();
                artikeldictionary = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
                artikeldictionary.Add(serialnumber, quantity);
                string items = JsonConvert.SerializeObject(artikeldictionary); // Hier zet je de dictionary om in een string
                Response.Cookies.Append("CartItems", items); // Hier voeg je de items toe aan de winkelwagen
                return Redirect("../../product/products");
            }
            Dictionary<int, int> artikel = new Dictionary<int, int>();
            artikel.Add(serialnumber, quantity);
            string item = JsonConvert.SerializeObject(artikel);
            Response.Cookies.Append("CartItems", item);
            return Redirect("../../product/Products");
        }

        public IActionResult CartRemove(CartItem Cartproduct)
        {
            string cookie = Request.Cookies["CartItems"];
            Dictionary<int, int> artikeldictionary = new Dictionary<int, int>();
            artikeldictionary = JsonConvert.DeserializeObject<Dictionary<int, int>>(cookie);
            artikeldictionary.Remove(Cartproduct.Product.SerialNumber + Cartproduct.Quantity);
            return Redirect("../../cart/cart");
        }

        [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
         string cookie =  Request.Cookies["cartitems"];
                ProductViewModel productModel = new ProductViewModel();
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();

                cart.Add(new CartItem { Product = productModel});
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
            return RedirectToAction("products", "Product");
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