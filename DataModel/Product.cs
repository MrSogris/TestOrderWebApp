using System;
using System.Collections.Generic;

namespace DataModel
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
