using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductLogic _productLogic;
        private readonly IColumnTableLogic _columnTableLogic;

        public ProductServices(IProductLogic productLogic, IColumnTableLogic columnTableLogic)
        {
            _productLogic = productLogic;
            _columnTableLogic = columnTableLogic;
        }

        public async Task<Response<int>> Save(ProductDto productDto)
        {
            Response<int> response;
            if(productDto.productId == 0)
            {
                response = (await this.Add(productDto));
            }
            else
            {
                response = (await this.Update(productDto));
            }

            return response;
        }

        public async Task<Response<int>> Add(ProductDto productDto)
        {
            Response<int> response = new Response<int>();
            var product = MapperProducts.DtoToEntity(productDto);

            response.data = (await _productLogic.Add(product));
            response.isSuccess = true;

            return response;
        }

        public async Task<Response<int>> Update(ProductDto productDto)
        {
            Response<int> response = new Response<int>();
            Product product = MapperProducts.DtoToEntity(productDto);

            response.data = (await _productLogic.Update(product));
            response.isSuccess = true;

            return response;
        }

        public async Task<int> Delete(int id)
        {
            var result = (await _productLogic.Delete(id));

            return result;
        }

        public async Task<Response<ProductDto>> Get(int id)
        {
            Response<ProductDto> response = new Response<ProductDto>();
            
            var product = (await _productLogic.Get(id));
            
            response.data = MapperProducts.EntityToDto(product); ;

            if(product.Id > 0)
                response.rowsAffected = 1;

            response.isSuccess = true;

            return response;
        }

        public async Task<ResponseGridView<IEnumerable<ProductDto>>> GetAll(ProductDto productDto)
        {
            int userId = 1;
            int tableId = 1;

            ResponseGridView<IEnumerable<ProductDto>> response = new ResponseGridView<IEnumerable<ProductDto>>();
            Product productSearch = MapperProducts.DtoToEntity(productDto);
            var product = (await _productLogic.GetAll(productSearch, productDto.page,productDto.search, productDto.orderBy));

            var productsDto = MapperProducts.EntitiesToDtos(product.ToList());

            var columnTable = await _columnTableLogic.GetColumnTableByUserId(userId, tableId);

            response.data = productsDto;
            if(productsDto.Count > 0)
            {
                response.rowsAffected = _productLogic.rowCounts;
            }
            response.isSuccess = true;
            return response;
        }
    }
}
