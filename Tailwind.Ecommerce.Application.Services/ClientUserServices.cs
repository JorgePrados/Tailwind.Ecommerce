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
    public class ClientUserServices : IClientUserServices
    {
        private readonly IClientUserLogic _clientUserLogic;

        public ClientUserServices(IClientUserLogic clientUserLogic)
        {
            _clientUserLogic = clientUserLogic;
        }

        public async Task<int> Add(ClientUserDto clientUserDto)
        {
            var clientUser = MapperClientUsers.DtoToEntity(clientUserDto);
            var result = (await _clientUserLogic.Add(clientUser));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _clientUserLogic.Delete(id));

            return result;
        }

        public async Task<ClientUserDto> Get(int id)
        {
            var clientUser = (await _clientUserLogic.Get(id));

            return MapperClientUsers.EntityToDto(clientUser);
        }

        public async Task<IEnumerable<ClientUserDto>> GetAll()
        {
            var clientUsers = (await _clientUserLogic.GetAll());

            return MapperClientUsers.EntitiesToDtos(clientUsers.ToList());
        }

        public async Task<int> Update(ClientUserDto clientUserDto)
        {
            ClientUser clientUser = MapperClientUsers.DtoToEntity(clientUserDto);

            int result = (await _clientUserLogic.Update(clientUser));

            return result;
        }
    }
}
