using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            var user = (await _userRepository.GetAll()).Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            return user;
        }
        public async Task<int> Add(User user)
        {
            var result = (await _userRepository.Add(user));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _userRepository.Delete(id));

            return result;
        }

        public async Task<User> Get(int id)
        {
            var user = (await _userRepository.Get(id));

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var user = (await _userRepository.GetAll());

            return user;
        }

        public async Task<int> Update(User user)
        {
            var result = (await _userRepository.Update(user));

            return result;
        }
    }
}
