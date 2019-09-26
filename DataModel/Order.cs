using System;
using System.Collections.Generic;

namespace DataModel
{
    public enum OrderStatus { InProgress = 0, Complete  = 1 }

    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string OrderName { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
