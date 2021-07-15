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
                clientDto.name = client.Name;
                clientDto.businessName = client.BusinessName;
                clientDto.cif = client.Cif;
                clientDto.description = client.Description;
                clientDto.contactPerson = client.ContactPerson;
                clientDto.contactPerson2 = client.ContactPerson2;
                clientDto.contactEmail = client.ContactEmail;
                clientDto.contactEmail2 = client.ContactEmail2;
                clientDto.contactPhone = client.ContactPhone;
                clientDto.contactPhone2 = client.ContactPhone2;
                clientDto.looked = client.Looked;
            }
            return clientDto;
        }

        public static Client DtoToEntity(ClientDto clientDto)
        {
            Client client = new Client();
            if (clientDto != null)
            {
                client.Id = clientDto.clientId;
                client.Name = clientDto.name;
                client.BusinessName = clientDto.businessName;
                client.Cif = clientDto.cif;
                client.Description = clientDto.description;
                client.ContactPerson = clientDto.contactPerson;
                client.ContactPerson2 = clientDto.contactPerson2;
                client.ContactEmail = clientDto.contactEmail;
                client.ContactEmail2 = clientDto.contactEmail2;
                client.ContactPhone = clientDto.contactPhone;
                client.ContactPhone2 = clientDto.contactPhone2;
                client.Looked = clientDto.looked;
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
