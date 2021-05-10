using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        [HttpGet("getClient")]
        public IActionResult GetClient()
        {
            return Ok("getClient");
        }

    }
}
