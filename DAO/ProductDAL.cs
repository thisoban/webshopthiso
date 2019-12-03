using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using Models;

namespace DAO
{
    public class ProductDAl : IProductDAL 
    {
        DAL DALAcces = new DAL();
        public ProductData GetProductDetail(int id)
        {
            ProductData data = new ProductData();
            string query = "Select * FROM Product WHERE Id = @Id";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Id", id));
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                data.Id = read.GetInt32(0);
                data.Name = read.GetString("Name");
                data.Description = read.GetString("Description");
                data.Quantity = read.GetInt32(3);
                data.Price = read.GetDecimal(4);
                
            }
            return data;
          
        }

        public List<ProductData> GetProducts()
        {
            List<ProductData> productList = new List<ProductData>();
            string query = "SELECT * FROM product";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                //read through all the data
                while (reader.Read())
                {
                    //create productlist
                    ProductData product = new ProductData();
                    product.Id = reader.GetInt32("Id");
                    product.Name = reader.GetString("Name");
                    product.Price = reader.GetDecimal("Sellprice");
                    product.Serialnumber = reader.GetInt32("Serialnumber");
                    // save uitlening to the list
                    productList.Add(product);
                }
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            DALAcces.conn.Close();
            return productList;
        }

        public bool InsertProduct()
        {
            
            throw new NotImplementedException();
        }

        public bool UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
