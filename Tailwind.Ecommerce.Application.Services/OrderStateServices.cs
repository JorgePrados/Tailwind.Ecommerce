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
    public class OrderStateServices : IOrderStateServices
    {
        private readonly IOrderStateLogic _orderStateLogic;

        public OrderStateServices(IOrderStateLogic orderStateLogic)
        {
            _orderStateLogic = orderStateLogic;
        }

        public async Task<int> Add(OrderStateDto orderStateDto)
        {
            var orderState = MapperOrderStates.DtoToEntity(orderStateDto);
            var result = (await _orderStateLogic.Add(orderState));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderStateLogic.Delete(id));

            return result;
        }

        public async Task<OrderStateDto> Get(int id)
        {
            var orderState = (await _orderStateLogic.Get(id));

            return MapperOrderStates.EntityToDto(orderState); ;
        }

        public async Task<IEnumerable<OrderStateDto>> GetAll()
        {
            var orderStates = (await _orderStateLogic.GetAll());

            return MapperOrderStates.EntitiesToDtos(orderStates.ToList());
        }

        public async Task<int> Update(OrderStateDto orderStateDto)
        {
            OrderState orderState = MapperOrderStates.DtoToEntity(orderStateDto);

            int result = (await _orderStateLogic.Update(orderState));

            return result;
        }
    }
}
