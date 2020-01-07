using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using IDAL;
using ILogic;

namespace Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IDALOrder order = DalFactory.DalFactory.GOrderDal();
        public OrderData AddOrder(OrderData orderNew)
        {
            if (orderNew.user.Email == String.Empty)
            {
                return new OrderData();
            }
            throw  new NotImplementedException();
        }

        public OrderData GetOrderDetail()
        {
            OrderData orderdetail = new OrderData();

            throw new NotImplementedException();
        }

        public List<OrderData> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
