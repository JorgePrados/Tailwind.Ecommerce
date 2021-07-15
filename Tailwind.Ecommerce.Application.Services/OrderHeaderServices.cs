using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class OrderHeaderServices : IOrderHeaderServices
    {
        private readonly IOrderHeaderLogic _orderHeaderLogic;

        public OrderHeaderServices(IOrderHeaderLogic orderHeaderLogic)
        {
            _orderHeaderLogic = orderHeaderLogic;
        }
        public async Task<int> Add(OrderHeaderDto orderHeaderDto)
        {
            var orderHeader = MapperOrderHeaders.DtoToEntity(orderHeaderDto);
            var result = (await _orderHeaderLogic.Add(orderHeader));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderHeaderLogic.Delete(id));

            return result;
        }

        public async Task<OrderHeaderDto> Get(int id)
        {
            var orderHeader = (await _orderHeaderLogic.Get(id));

            return MapperOrderHeaders.EntityToDto(orderHeader);
        }

        public async Task<IEnumerable<OrderHeaderDto>> GetAll()
        {
            var orderHeaders = (await _orderHeaderLogic.GetAll());

            return MapperOrderHeaders.EntitiesToDtos(orderHeaders.ToList());
        }

        public async Task<int> Update(OrderHeaderDto orderHeaderDto)
        {
            OrderHeader orderHeader = MapperOrderHeaders.DtoToEntity(orderHeaderDto);

            int result = (await _orderHeaderLogic.Update(orderHeader));

            return result;
        }
    }
}
