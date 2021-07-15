using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IOrderStateServices
    {
        Task<int> Add(OrderStateDto orderState);
        Task<int> Delete(int id);
        Task<OrderStateDto> Get(int id);
        Task<IEnumerable<OrderStateDto>> GetAll();
        Task<int> Update(OrderStateDto orderState);
    }
}
