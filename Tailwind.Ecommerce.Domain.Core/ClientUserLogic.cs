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
    public class ClientUserLogic: IClientUserLogic
    {
        private readonly IClientUserRepository _clientUserRepository;
        public ClientUserLogic(IClientUserRepository clientUserRepository)
        {
            _clientUserRepository = clientUserRepository;
        }

        public async Task<int> Add(ClientUser clientUser)
        {
            var result = (await _clientUserRepository.Add(clientUser));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _clientUserRepository.Delete(id));

            return result;
        }

        public async Task<ClientUser> Get(int id)
        {
            var clientUser = (await _clientUserRepository.Get(id));

            return clientUser;
        }

        public async Task<IEnumerable<ClientUser>> GetAll()
        {
            var clientUser = (await _clientUserRepository.GetAll());

            return clientUser;
        }

        public async Task<int> Update(ClientUser clientUser)
        {
            var result = (await _clientUserRepository.Update(clientUser));

            return result;
        }
    }
}
