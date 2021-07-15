using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientLogic _clientLogic;

        public ClientServices(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }

        public async Task<int> Add(ClientDto clientDto)
        {
            var client = MapperClients.DtoToEntity(clientDto);
            var result = (await _clientLogic.Add(client));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _clientLogic.Delete(id));

            return result;
        }

        public async Task<ClientDto> Get(int id)
        {
            var client = (await _clientLogic.Get(id));

            return MapperClients.EntityToDto(client); ;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var clients = (await _clientLogic.GetAll());

            return MapperClients.EntitiesToDtos(clients.ToList());
        }

        public async Task<int> Update(ClientDto clientDto)
        {
            Client client = MapperClients.DtoToEntity(clientDto);

            int result = (await _clientLogic.Update(client));

            return result;
        }
    }
}
