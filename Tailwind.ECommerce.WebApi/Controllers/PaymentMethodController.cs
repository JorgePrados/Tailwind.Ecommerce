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
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodServices _paymentMethodServices;
        private readonly AppSettings _appSettings;
        public PaymentMethodController(IPaymentMethodServices paymentMethodServices, IOptions<AppSettings> appSettings)
        {
            _paymentMethodServices = paymentMethodServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PaymentMethodDto paymentMethodDto)
        {
            var result = (await _paymentMethodServices.Add(paymentMethodDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _paymentMethodServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var paymentMethods = (await _paymentMethodServices.Get(id));

            return Ok(paymentMethods);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var paymentMethods = (await _paymentMethodServices.GetAll());

            return Ok(paymentMethods);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(PaymentMethodDto paymentMethodDto)
        {
            int result = (await _paymentMethodServices.Update(paymentMethodDto));

            return Ok(result);
        }
    }
}
