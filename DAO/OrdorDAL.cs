using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using IDAL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class OrdorDAL : IDALOrder
    {
        public bool DeleteOrder(int serialnumber)
        {
            //if (serialnumber != null)
            //{
            //    return true;
            //}
            return false;
            throw new NotImplementedException();
        }

        public OrderData GetOrder()
        {
            throw new NotImplementedException();
        }

        public List<OrderData> GetOrders()
        {
            throw new NotImplementedException();
        }

        public bool InsertOrder()
        {
            throw new NotImplementedException();
        }
        public void DeleteOrder()
        {
            
        }
    }
}
