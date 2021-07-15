using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.ECommerce.WebApi.Helpers;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly AppSettings _appSettings;
        public ProductController(IProductServices productServices, IOptions<AppSettings> appSettings)
        {
            _productServices = productServices;
            _appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var result = (await _productServices.Add(productDto));

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = (await _productServices.Delete(productId));

            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = (await _productServices.Get(productId));

            return Ok(product);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll(ProductDto productDto)
        {
            var products = (await _productServices.GetAll(productDto));

            return Ok(products);
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            Response<int> result = (await _productServices.Update(productDto));

            return Ok(result);
        }


        [HttpPost("save")]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            Response<int> result = (await _productServices.Save(productDto));
          
            return Ok(result);
        }

    }
}
