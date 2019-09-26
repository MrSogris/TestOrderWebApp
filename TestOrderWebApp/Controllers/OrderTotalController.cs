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
    public class OrderTotalController : OrderBaseController
    {
        public OrderTotalController(DataModel.TestOrderDBContext Context)
        {
            OrderDB = Context;
        }

        [HttpGet("{OrderId}")]
        public IActionResult Get(Int32 OrderId)
        {
            try
            {
                OrderDetailProvider Provider = new OrderDetailProvider(OrderDB);
                OrderTotal Total = Provider.GetTotalForOrder(OrderId);

                if (Total == null)
                    return NotFound();

                return new ObjectResult(Total);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}