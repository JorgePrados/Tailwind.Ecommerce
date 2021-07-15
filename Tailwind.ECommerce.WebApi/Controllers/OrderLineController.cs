using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.ECommerce.WebApi.Helpers;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderLineController : Controller
    {
        private readonly IOrderLineServices _orderLineServices;
        public OrderLineController(IOrderLineServices orderLineServices, IOptions<AppSettings> appSettings)
        {
            _orderLineServices = orderLineServices;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OrderLineDto orderLineDto)
        {
            var result = (await _orderLineServices.Add(orderLineDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _orderLineServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var orderLines = (await _orderLineServices.Get(id));

            return Ok(orderLines);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var orderLines = (await _orderLineServices.GetAll());

            return Ok(orderLines);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(OrderLineDto orderLineDto)
        {
            int result = (await _orderLineServices.Update(orderLineDto));

            return Ok(result);
        }
    }
}
