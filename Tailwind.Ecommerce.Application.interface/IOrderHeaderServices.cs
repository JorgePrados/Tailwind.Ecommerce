using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IOrderHeaderServices
    {
        Task<int> Add(OrderHeaderDto orderHeader);
        Task<int> Delete(int id);
        Task<OrderHeaderDto> Get(int id);
        Task<IEnumerable<OrderHeaderDto>> GetAll();
        Task<int> Update(OrderHeaderDto orderHeader);
    }
}
