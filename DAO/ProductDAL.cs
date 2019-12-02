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
            List<ProductData> products = new List<ProductData>();

            string query = "SELECT * FROM product";
            DALAcces.conn.Open();
            return products;
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
