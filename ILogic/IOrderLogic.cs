using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace ILogic
{
    public interface IOrderLogic
    {
        OrderData AddOrder();
        List<OrderData> GetOrders();
        OrderData GetOrderDetail();

    }
}
