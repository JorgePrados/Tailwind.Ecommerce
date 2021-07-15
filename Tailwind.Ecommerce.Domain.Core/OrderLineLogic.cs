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
    public class OrderLineLogic: IOrderLineLogic
    {
        private readonly IOrderLineRepository _orderLineRepository;
        public OrderLineLogic(IOrderLineRepository orderLineRepository)
        {
            _orderLineRepository = orderLineRepository;
        }

        public async Task<int> Add(OrderLine orderLine)
        {
            var result = (await _orderLineRepository.Add(orderLine));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _orderLineRepository.Delete(id));

            return result;
        }

        public async Task<OrderLine> Get(int id)
        {
            var orderLine = (await _orderLineRepository.Get(id));

            return orderLine;
        }

        public async Task<IEnumerable<OrderLine>> GetAll()
        {
            var orderLines = (await _orderLineRepository.GetAll());

            return orderLines;
        }

        public async Task<int> Update(OrderLine orderLine)
        {
            var result = (await _orderLineRepository.Update(orderLine));

            return result;
        }
    }
}
