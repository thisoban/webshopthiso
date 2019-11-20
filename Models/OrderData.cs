using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class OrderData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public List<OrderLineData> productline { get; set; }
    }
}
