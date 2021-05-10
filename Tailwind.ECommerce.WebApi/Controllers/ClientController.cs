using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;
        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpGet("getAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            List<ClientDto> ClientsDto = await _clientServices.GetAllClients();
            return Ok(ClientsDto);
        }
    }
}
