using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOrderWebApp.Models;

namespace TestOrderWebApp.Providers
{
    public class OrderProvider
    {
        DataModel.TestOrderDBContext OrderDB;

        static Order CreateFromDataModel(DataModel.Order Source)
        {
            return new Order() { Id = Source.Id, CreateDate = Source.CreateDate, OrderName = Source.OrderName, Status = Source.Status.ToString() };
        }

        public OrderProvider(DataModel.TestOrderDBContext DBContext)
        {
            OrderDB = DBContext;
        }

        public IEnumerable<Order> GetAll()
        {
            IEnumerable<Order> OrdersList = OrderDB.Orders.ToList().Select(x => CreateFromDataModel(x)).ToList();

            return OrdersList;
        }

        public Order Get(Int32 Id)
        {
            DataModel.Order FoundOrder = OrderDB.Orders.FirstOrDefault(x=>x.Id == Id);

            if(FoundOrder == null)
            {
                return null;
            }

            return CreateFromDataModel(FoundOrder);
        }
    }
}
