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
    public class ClientLogic : IClientLogic
    {
        private readonly IClientRepository _clientRepository;
        public ClientLogic(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Add(Client client)
        {
            var result = (await _clientRepository.Add(client));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _clientRepository.Delete(id));

            return result;
        }

        public async Task<Client> Get(int id)
        {
            var client = (await _clientRepository.Get(id));

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var client = (await _clientRepository.GetAll());

            return client;
        }

        public async Task<int> Update(Client client)
        {
            var result = (await _clientRepository.Update(client));

            return result;
        }
    }
}
