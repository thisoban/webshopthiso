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
            string query = "Select * from Product WHERE Id = @Id";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Id", id));
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                data.Id = read.GetInt32(0);
                data.Name = read.GetString("Name");
                data.Price = read.GetDouble(3);
                data.Quantity = read.GetInt32(0);
                data.Description = read.GetString("Description");
            }
            return data;
          
        }

        public List<ProductData> GetProducts()
        {
            throw new NotImplementedException();
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
