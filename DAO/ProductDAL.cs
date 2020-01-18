using IDAL;
using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DAL
{
    public class ProductDAl : IProductDAL 
    {
        private readonly DAL DALAcces = new DAL();
        public ProductData GetProductDetail(int serialnumber)
        {
            DALAcces.conn.Open();
            ProductData data = new ProductData();
            string query = "Select * FROM Product WHERE serialnumber = @SerialNumber";
         
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@SerialNumber", serialnumber));
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Id = reader.GetInt32(0);
                    data.Name = reader.GetString("Name");
                    data.Description = reader.GetString("Description");
                    data.Quantity = reader.GetInt32(3);
                    data.Price = reader.GetDecimal(4);
                    data.Serialnumber = reader.GetInt32(5);

                }

                DALAcces.conn.Close();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DALAcces.conn.Close();
            }
            
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
                    ProductData product = new ProductData
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("Name"),
                        Price = reader.GetDecimal("Sellprice"),
                        Quantity = reader.GetInt32("Quantity"),
                        Serialnumber = reader.GetInt32("Serialnumber")
                    };
                    // save uitlening to the list
                    productList.Add(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DALAcces.conn.Close();
            }
          
            return productList;
        }

        public bool InsertProduct(ProductData newProduct)
        {
            string query = "INSERT INTO product(Name, Description, Quantity, Sellprice, Serialnumber) " +
                           "VALUES (@name,@description,@quantity,@sellprice,@serialnumber)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@name", newProduct.Name));
            command.Parameters.Add(new MySqlParameter("@description", newProduct.Description));
            command.Parameters.Add(new MySqlParameter("@quantity", newProduct.Quantity));
            command.Parameters.Add(new MySqlParameter("@sellprice", newProduct.Price));
            command.Parameters.Add(new MySqlParameter("@serialnumber", newProduct.Serialnumber));
            try
            {
                command.ExecuteNonQuery();
                if (command.ExecuteNonQuery().Equals(1))
                {
                    DALAcces.conn.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DALAcces.conn.Close();
            }
          
            return false;
        }

        public bool UpdateProduct(ProductData upProduct)
        {
            DALAcces.conn.Open();
            string query =
                "UPDATE product SET  Name = @name, Description = @description, Quantity = @quantity, Sellprice =@sellprice WHERE Serialnumber = @serialnumber";
            
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@name", upProduct.Name));
            command.Parameters.Add(new MySqlParameter("@description", upProduct.Description));
            command.Parameters.Add(new MySqlParameter("@quantity", upProduct.Quantity));
            command.Parameters.Add(new MySqlParameter("@sellprice", upProduct.Price));
            command.Parameters.Add(new MySqlParameter("@serialnumber", upProduct.Serialnumber));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                DALAcces.conn.Close();
            }
        }

       
    }
}
