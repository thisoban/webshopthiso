using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class OrderData
    {
        public int Id { get; set; }
        public UserData user { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderLineData> Productlines { get; set; }
    }
}
