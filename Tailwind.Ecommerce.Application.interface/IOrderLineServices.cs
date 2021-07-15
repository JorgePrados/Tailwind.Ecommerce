using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IOrderLineServices
    {
        Task<int> Add(OrderLineDto orderLine);
        Task<int> Delete(int id);
        Task<OrderLineDto> Get(int id);
        Task<IEnumerable<OrderLineDto>> GetAll();
        Task<int> Update(OrderLineDto orderLine);
    }
}
