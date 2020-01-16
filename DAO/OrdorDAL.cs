using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using IDAL;
using Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class OrdorDAL : IDALOrder
    {
        private readonly DAL DALAcces = new DAL();
        public bool DeleteOrder(int serialnumber)
        {
            throw new NotImplementedException();
        }

        public OrderData GetOrder()
        {
            throw new NotImplementedException();
        }

        public List<OrderData> GetOrders()
        {
            List<OrderData> orderList = new List<OrderData>();
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
                    OrderData order = new OrderData
                    {
                        Id = reader.GetInt32("IdUser"),
                        OrderNumber = reader.GetString("Name"),
                        
                    };
                    // save uitlening to the list
                    orderList.Add(order);
                }
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            finally
            {
                DALAcces.conn.Close();
            }

            return orderList;
            throw new NotImplementedException();
        }

        public bool InsertOrder()
        {
            throw new NotImplementedException();
        }
    }
}
