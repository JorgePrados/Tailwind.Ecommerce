using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IUserLogic
    {
        Task<User> Authenticate(string userName, string password);
        Task<int> Add(User user);
        Task<int> Delete(int id);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task<int> Update(User user);
    }
}
