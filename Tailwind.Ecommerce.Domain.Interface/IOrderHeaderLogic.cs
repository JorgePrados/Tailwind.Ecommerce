using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IOrderHeaderLogic
    {
        Task<int> Add(OrderHeader orderHeader);
        Task<int> Delete(int id);
        Task<OrderHeader> Get(int id);
        Task<IEnumerable<OrderHeader>> GetAll();
        Task<int> Update(OrderHeader orderHeader);
    }
}
