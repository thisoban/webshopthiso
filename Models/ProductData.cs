using System;

namespace Models
{
    public class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Serialnumber { get; set; }
        public ProductData()
        {

        }
        public ProductData(string name, string description, decimal price, int quantity, int serialnumber)
        {
            
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Serialnumber = serialnumber;
        }
       

      

    }
}
