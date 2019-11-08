using System;

namespace Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, string description, double price, int quantity)
        {
            
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
       

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
