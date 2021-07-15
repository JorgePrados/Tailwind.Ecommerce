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
    public class ClientUserController : Controller
    {
        private readonly IClientUserServices _clientUserServices;
        private readonly AppSettings _appSettings;
        public ClientUserController(IClientUserServices clientUserServices, IOptions<AppSettings> appSettings)
        {
            _clientUserServices = clientUserServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ClientUserDto clientUserDto)
        {
            var result = (await _clientUserServices.Add(clientUserDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _clientUserServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var clientUser = (await _clientUserServices.Get(id));

            return Ok(clientUser);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var clientUsers = (await _clientUserServices.GetAll());

            return Ok(clientUsers);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ClientUserDto clientUserDto)
        {
            int result = (await _clientUserServices.Update(clientUserDto));

            return Ok(result);
        }
    }
}
