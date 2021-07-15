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
    public class OrderStateController : Controller
    {
        private readonly IOrderStateServices _orderStateServices;
        private readonly AppSettings _appSettings;
        public OrderStateController(IOrderStateServices orderStateServices, IOptions<AppSettings> appSettings)
        {
            _orderStateServices = orderStateServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OrderStateDto orderStateDto)
        {
            var result = (await _orderStateServices.Add(orderStateDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _orderStateServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var orderStates = (await _orderStateServices.Get(id));

            return Ok(orderStates);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var orderStates = (await _orderStateServices.GetAll());

            return Ok(orderStates);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(OrderStateDto orderStateDto)
        {
            int result = (await _orderStateServices.Update(orderStateDto));

            return Ok(result);
        }
    }
}
