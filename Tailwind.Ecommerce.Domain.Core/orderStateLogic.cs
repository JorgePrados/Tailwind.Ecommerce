using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class OrderStateLogic : IOrderStateLogic
    {
        private readonly IOrderStateRepository _orderStateRepository;
        public OrderStateLogic(IOrderStateRepository orderStateRepository)
        {
            _orderStateRepository = orderStateRepository;
        }

        public async Task<int> Add(OrderState orderState)
        {
            var result = (await _orderStateRepository.Add(orderState));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderStateRepository.Delete(id));

            return result;
        }

        public async Task<OrderState> Get(int id)
        {
            var orderState = (await _orderStateRepository.Get(id));

            return orderState;
        }

        public async Task<IEnumerable<OrderState>> GetAll()
        {
            var orderState = (await _orderStateRepository.GetAll());

            return orderState;
        }

        public async Task<int> Update(OrderState orderState)
        {
            var result = (await _orderStateRepository.Update(orderState));

            return result;
        }
    }
}
