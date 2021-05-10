using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class ClientServices: IClientServices
    {
        private readonly IClientLogic _clientLogic;
        public ClientServices(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }
        public async Task<List<ClientDto>> GetAllClients()
        {
            var clients = await _clientLogic.GetAllClients();
            return MapperClients.EntitiesToDtos(clients);
        }
    }
}
