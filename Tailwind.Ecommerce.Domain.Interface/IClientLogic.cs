using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IClientLogic
    {
        Task<int> Add(Client client);
        Task<int> Delete(int id);
        Task<Client> Get(int id);
        Task<IEnumerable<Client>> GetAll();
        Task<int> Update(Client client);
    }
}
