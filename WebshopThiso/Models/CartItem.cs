using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopThiso.Models
{
    public class CartItem
    {
        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
