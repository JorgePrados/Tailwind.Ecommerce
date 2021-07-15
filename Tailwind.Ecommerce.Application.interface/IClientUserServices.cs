using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IClientUserServices
    {
        Task<int> Add(ClientUserDto clientUser);
        Task<int> Delete(int id);
        Task<ClientUserDto> Get(int id);
        Task<IEnumerable<ClientUserDto>> GetAll();
        Task<int> Update(ClientUserDto clientUser);
    }
}
