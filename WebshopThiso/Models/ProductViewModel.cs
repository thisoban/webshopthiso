using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebshopThiso.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int SerialNumber { get; set; }

        public ProductViewModel()
        {

        }
        public ProductViewModel(ProductData product)
        {
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
            Quantity = product.Quantity;
            SerialNumber = product.Serialnumber;
        }
        public ProductViewModel(string name, decimal price, string descriptionm, int quantity, int serialnumber)
        {
            Name = name;
            Price = price;
            Description = descriptionm;
            Quantity = quantity;
            SerialNumber = serialnumber;
        }
    }
}
