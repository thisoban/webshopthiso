using System;
using System.Collections.Generic;
using System.Text;
using Models;
using MySql.Data.MySqlClient;

namespace DAO
{
   public class ProductDAL : DAL
    {
        public Product GetProduct(int id)
        {
            string query = "SELECT * FROM Product WHERE Id = @Id";

            Product returnproduct = new Product();
            conn.Open();
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.Add(new MySqlParameter("@Id", id));
               
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    read.GetInt32(0);
                    read.GetInt32(1);
                    read.GetInt32(2);
                    read.GetInt32(3);
                }

            }
            conn.Close();

            return returnproduct;
        }
        public List<Product> GetProducts(int id)
        {
            List<Product> producten = new List<Product>();

            string query = "SELECT * FROM Product ";
           
            conn.Open();
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {

                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    read.GetInt32(0);
                    read.GetInt32(1);
                    read.GetInt32(2);
                    read.GetInt32(3);
                    
                }

            }
            conn.Close();

            return  producten;
        }
    }
}
