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
            string query = "SELECT * FROM ordor WHERE CustomUser_Id = @uid";
            
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    OrderData order = new OrderData
                    {
                        OrderNumber = reader.GetString("ordernumber"),
                            Date =  reader.GetDateTime("date")
                    };
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
        }

        public bool InsertOrder()
        {
            throw new NotImplementedException();
        }
    }
}
