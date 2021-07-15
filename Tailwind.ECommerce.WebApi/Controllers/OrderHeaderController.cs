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
    public class OrderHeaderController : Controller
    {
        private readonly IOrderHeaderServices _orderHeaderServices;
        public OrderHeaderController(IOrderHeaderServices orderHeaderServices, IOptions<AppSettings> appSettings)
        {
            _orderHeaderServices = orderHeaderServices;
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add(OrderHeaderDto orderHeaderDto)
        {
            var result = (await _orderHeaderServices.Add(orderHeaderDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _orderHeaderServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var orderHeader = (await _orderHeaderServices.Get(id));

            return Ok(orderHeader);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var orderHeaders = (await _orderHeaderServices.GetAll());

            return Ok(orderHeaders);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(OrderHeaderDto orderHeaderDto)
        {
            int result = (await _orderHeaderServices.Update(orderHeaderDto));

            return Ok(result);
        }
    }
}
