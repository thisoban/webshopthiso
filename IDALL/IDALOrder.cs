using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace IDAL
{
    public interface IDALOrder
    {
        bool InsertOrder();
        List<OrderData> GetOrders();
        OrderData GetOrder();
        bool DeleteOrder(int serialnumber);
    }
}
