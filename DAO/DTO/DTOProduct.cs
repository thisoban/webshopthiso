using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class DTOProduct
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Double price;

        public Double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public DTOProduct(int id, string name, double price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public List<DTOProduct> TestProducts() 
        {

            return null;
        }
    }
}
