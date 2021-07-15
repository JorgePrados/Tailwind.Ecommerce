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
    public class OrderHeaderLogic: IOrderHeaderLogic
    {
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        public OrderHeaderLogic(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public async Task<int> Add(OrderHeader user)
        {
            var result = (await _orderHeaderRepository.Add(user));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderHeaderRepository.Delete(id));

            return result;
        }

        public async Task<OrderHeader> Get(int id)
        {
            var orderHeader = (await _orderHeaderRepository.Get(id));

            return orderHeader;
        }

        public async Task<IEnumerable<OrderHeader>> GetAll()
        {
            var ordersHeaders = (await _orderHeaderRepository.GetAll());

            return ordersHeaders;
        }

        public async Task<int> Update(OrderHeader orderHeader)
        {
            var result = (await _orderHeaderRepository.Update(orderHeader));

            return result;
        }
    }
}
