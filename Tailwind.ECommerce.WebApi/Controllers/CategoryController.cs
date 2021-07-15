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
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly AppSettings _appSettings;
        public CategoryController(ICategoryServices categoryServices, IOptions<AppSettings> appSettings)
        {
            _categoryServices = categoryServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            var result = (await _categoryServices.Add(categoryDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _categoryServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var category = (await _categoryServices.Get(id));

            return Ok(category);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = (await _categoryServices.GetAll());

            return Ok(categories);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            int result = (await _categoryServices.Update(categoryDto));

            return Ok(result);
        }
    }
}
