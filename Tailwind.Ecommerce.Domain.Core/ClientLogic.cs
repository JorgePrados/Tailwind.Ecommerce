using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class ClientLogic: IClientLogic
    {
        private readonly IClientRepository _clientRepository;
        public ClientLogic(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetAllClients()
        {

            var clients = await _clientRepository.GetAll();

            return clients.ToList();
        }
    }
}
