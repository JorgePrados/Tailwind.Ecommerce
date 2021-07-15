using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IUserServices
    {
        Task<UserDto> Authenticate(string userName, string password);
        Task<int> Add(UserDto user);
        Task<int> Delete(int id);
        Task<UserDto> Get(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<int> Update(UserDto user);
    }
}
