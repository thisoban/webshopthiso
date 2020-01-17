using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class OrderData
    {
     
        public UserData User { get; set; }
        public string OrderNumber { get; set; }
       public DateTime Date { get; set; }
        public List<OrderLineData> Productlines { get; set; }
    }
}
