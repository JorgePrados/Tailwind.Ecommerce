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
    public class OrderLineServices : IOrderLineServices
    {
        private readonly IOrderLineLogic _orderLineLogic;

        public OrderLineServices(IOrderLineLogic orderLineLogic)
        {
            _orderLineLogic = orderLineLogic;
        }

        public async Task<int> Add(OrderLineDto orderLineDto)
        {
            var orderLine = MapperOrderLines.DtoToEntity(orderLineDto);
            var result = (await _orderLineLogic.Add(orderLine));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderLineLogic.Delete(id));

            return result;
        }

        public async Task<OrderLineDto> Get(int id)
        {
            var orderLine = (await _orderLineLogic.Get(id));

            return MapperOrderLines.EntityToDto(orderLine);
        }

        public async Task<IEnumerable<OrderLineDto>> GetAll()
        {
            var orderLines = (await _orderLineLogic.GetAll());

            return MapperOrderLines.EntitiesToDtos(orderLines.ToList());
        }

        public async Task<int> Update(OrderLineDto orderLineDto)
        {
            OrderLine orderLine = MapperOrderLines.DtoToEntity(orderLineDto);

            int result = (await _orderLineLogic.Update(orderLine));

            return result;
        }
    }
}
