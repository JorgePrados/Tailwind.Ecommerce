using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IOrderStateLogic
    {
        Task<int> Add(OrderState orderState);
        Task<int> Delete(int id);
        Task<OrderState> Get(int id);
        Task<IEnumerable<OrderState>> GetAll();
        Task<int> Update(OrderState orderState);
    }
}
