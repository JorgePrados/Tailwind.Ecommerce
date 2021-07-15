using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IOrderLineLogic
    {
        Task<int> Add(OrderLine orderLine);
        Task<int> Delete(int id);
        Task<OrderLine> Get(int id);
        Task<IEnumerable<OrderLine>> GetAll();
        Task<int> Update(OrderLine orderLine);
    }
}
