using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestOrderWebApp.Models;
using TestOrderWebApp.Providers;

namespace TestOrderWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : OrderBaseController
    {
        public OrderDetailsController(DataModel.TestOrderDBContext Context)
        {
            OrderDB = Context;
        }

        [HttpGet("{OrderId}")]
        public IActionResult Get(Int32 OrderId)
        {
            try
            {
                OrderDetailProvider Provider = new OrderDetailProvider(OrderDB);
                IEnumerable<OrderDetail> Details = Provider.GetDetailsForOrder(OrderId);

                if (Details == null)
                    return NotFound();

                return new ObjectResult(Details);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}