using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using IDAL;
using ILogic;

namespace Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IDALOrder IOrder = DalFactory.DalFactory.GOrderDal();
        public OrderData AddOrder(OrderData orderNew)
        {
            if (orderNew.User.Email == String.Empty)
            {
                return new OrderData();
            }
            throw  new NotImplementedException();
        }

        public OrderData GetOrderDetail(int ordernumber)
        {
            OrderData orderdetail = new OrderData();

            throw new NotImplementedException();
        }

        public List<OrderData> GetOrders(int uid)
        {
            List<OrderData> logicOrderData = new List<OrderData>();
            if (IOrder.GetOrders().Count >= 0)
            {
                logicOrderData = IOrder.GetOrders();
                return logicOrderData;
            }

            return logicOrderData;
        }
    }
}
