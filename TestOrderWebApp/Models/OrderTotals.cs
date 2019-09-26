using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOrderWebApp.Models
{
    public class OrderTotal
    {
        public Int32 OrderId { get; set; }

        public Int32 TotalQuantity { get; set; }

        public Double TotalValue { get; set; }
    }
}
