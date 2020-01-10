using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataModel
{
    public class CartData
    { 
      
        public ProductData productdetails { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
