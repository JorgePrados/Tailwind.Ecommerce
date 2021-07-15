using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IClientServices
    {
        Task<int> Add(ClientDto client);
        Task<int> Delete(int id);
        Task<ClientDto> Get(int id);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<int> Update(ClientDto client);
    }
}
