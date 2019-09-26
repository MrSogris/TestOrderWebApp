using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestOrderWebApp.Models;

namespace TestOrderWebApp.Providers
{
    public class OrderDetailProvider
    {
        DataModel.TestOrderDBContext OrderDB;

        static OrderDetail CreateFromDataModel(DataModel.OrderDetail Source)
        {
            return new OrderDetail() { Id = Source.Id, OrderId = Source.OrderId, Price = Source.Price, Product = Source.Product.ProductName, ProductId = Source.ProductId, Quantity = Source.Quantity, Total = Source.Total };
        }

        public OrderDetailProvider(DataModel.TestOrderDBContext DBContext)
        {
            OrderDB = DBContext;
        }

        public IEnumerable<OrderDetail> GetDetailsForOrder(Int32 OrderId)
        {
            IEnumerable<OrderDetail> Details = OrderDB.OrderDetails.Include(x => x.Product).Where(x => x.OrderId == OrderId).AsEnumerable().Select(x => CreateFromDataModel(x)); //include products to avoid excess SQL queries

            if(!OrderDB.Orders.Any(x=>x.Id == OrderId))
            {
                return null;
            }

            return Details;
        }

        public OrderTotal GetTotalForOrder(Int32 OrderId)
        {
            DataModel.Order TargetOrder = OrderDB.Orders.Include(x => x.OrderDetails).FirstOrDefault(x => x.Id == OrderId);

            if (TargetOrder == null)
                return null;

            return new OrderTotal() { OrderId = OrderId, TotalQuantity = TargetOrder.OrderDetails.Sum(x => x.Quantity), TotalValue = TargetOrder.OrderDetails.Sum(x => x.Total) };
        }
    }
}
