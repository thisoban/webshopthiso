using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
namespace ILogic
{
    public interface IOrderLogic
    {
        OrderData AddOrder(OrderData order);
        List<OrderData> GetOrders();
        OrderData GetOrderDetail();

    }
}
