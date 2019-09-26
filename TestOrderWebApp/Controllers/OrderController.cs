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
    public class OrderController : OrderBaseController
    {
        public OrderController(DataModel.TestOrderDBContext Context)
        {
            OrderDB = Context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                OrderProvider Provider = new OrderProvider(OrderDB);
                IEnumerable<Order> OrdersList = Provider.GetAll();

                return new ObjectResult(OrdersList);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Int32 Id)
        {
            try
            {
                OrderProvider Provider = new OrderProvider(OrderDB);
                Order FoundOrder = Provider.Get(Id);

                if (FoundOrder == null)
                    return NotFound();

                return new ObjectResult(FoundOrder);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}