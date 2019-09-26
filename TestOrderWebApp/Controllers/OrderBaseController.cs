using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestOrderWebApp.Controllers
{
    public abstract class OrderBaseController : ControllerBase
    {
        protected DataModel.TestOrderDBContext OrderDB;
    }
}
