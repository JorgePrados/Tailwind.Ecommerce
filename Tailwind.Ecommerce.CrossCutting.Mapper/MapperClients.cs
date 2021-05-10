using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperClients
    {
        public static ClientDto EntityToDto(Client client)
        {
            ClientDto clientDto = new ClientDto();
            if (client != null)
            {
                clientDto.clientId = client.Id;
                clientDto.Name = client.Name;
            }
            return clientDto;
        }

        public static Client DtoToEntity(ClientDto clientDto)
        {
            Client client = new Client();
            if (clientDto != null)
            {
                client.Id = clientDto.clientId;
                client.Name = clientDto.Name;
            }
            return client;
        }

        public static List<ClientDto> EntitiesToDtos(List<Client> clients)
        {
            List<ClientDto> clientsDto = new List<ClientDto>();

            foreach(var client in clients)
            {
                clientsDto.Add(EntityToDto(client));
            }
            return clientsDto;
        }

        public static List<Client> DtosToEntities(List<ClientDto> clientsDto)
        {
            List<Client> clients = new List<Client>();

            foreach (var clientDto in clientsDto)
            {
                clients.Add(DtoToEntity(clientDto));
            }
            return clients;
        }
    }
}
