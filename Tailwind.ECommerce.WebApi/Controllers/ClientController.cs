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
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;
        private readonly AppSettings _appSettings;
        public ClientController(IClientServices clientServices, IOptions<AppSettings> appSettings)
        {
            _clientServices = clientServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ClientDto clientDto)
        {
            var result = (await _clientServices.Add(clientDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _clientServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var client = (await _clientServices.Get(id));

            return Ok(client);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await _clientServices.GetAll());

            return Ok(clients);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ClientDto clientDto)
        {
            int result = (await _clientServices.Update(clientDto));

            return Ok(result);
        }
    }
}
