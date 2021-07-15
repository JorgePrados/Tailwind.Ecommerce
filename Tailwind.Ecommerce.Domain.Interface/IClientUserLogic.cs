using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IClientUserLogic
    {
        Task<int> Add(ClientUser clientUser);
        Task<int> Delete(int id);
        Task<ClientUser> Get(int id);
        Task<IEnumerable<ClientUser>> GetAll();
        Task<int> Update(ClientUser clientUser);
    }
}
