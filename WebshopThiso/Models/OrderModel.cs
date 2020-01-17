using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;

namespace WebshopThiso.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public UserViewModel user { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public List<OrderLineData> Productlines { get; set; }

    }
}
