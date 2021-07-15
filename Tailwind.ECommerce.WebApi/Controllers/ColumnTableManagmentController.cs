using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColumnTableManagmentController : Controller
    {
        private readonly IColumnTableManagmentServices _columnTableManagmentServices;
        public ColumnTableManagmentController(IColumnTableManagmentServices columnTableManagmentServices)
        {
            _columnTableManagmentServices = columnTableManagmentServices;
        }

        [HttpGet("getColumnsTable")]
        public async Task<IActionResult> GetColumnsTable(int tableId)
        {
            int userId = 1;
            var result = await _columnTableManagmentServices.GetColumnsTable(userId,tableId);
            return Ok(result);
        }

        [HttpPost("addConfigurationColumnsTable")]
        public async Task<IActionResult> AddConfigurationColumnsTable(List<ColumnTableDto> columnTableDtos)
        {

            int userId = 1;
            var result = await _columnTableManagmentServices.AddConfigurationColumnsTable(columnTableDtos, userId);
            return Ok(result);
        }
    }
}
