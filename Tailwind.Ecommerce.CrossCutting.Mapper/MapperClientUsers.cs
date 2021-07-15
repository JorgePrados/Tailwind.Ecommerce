using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperClientUsers
    {
        public static ClientUserDto EntityToDto(ClientUser clientUser)
        {
            ClientUserDto clientUserDto = new ClientUserDto();
            if (clientUser != null)
            {
                clientUserDto.ClientUserId = clientUser.Id;
                clientUserDto.userName = clientUser.UserName;
                clientUserDto.password = clientUser.Password;
                clientUserDto.name = clientUser.Name;
                clientUserDto.clientId = clientUser.ClientId;
                clientUserDto.client = MapperClients.EntityToDto(clientUser.Client);
                clientUserDto.firstName = clientUser.FirstName;
                clientUserDto.lastName = clientUser.LastName;
                clientUserDto.email = clientUser.Email;
                clientUserDto.phone = clientUser.Phone;
}
            return clientUserDto;
        }

        public static ClientUser DtoToEntity(ClientUserDto clientUserDto)
        {
            ClientUser clientUser = new ClientUser();
            if (clientUserDto != null)
            {
                clientUser.Id = clientUserDto.ClientUserId;
                clientUser.UserName = clientUserDto.userName;
                clientUser.Password = clientUserDto.password;
                clientUser.Name = clientUserDto.name;
                clientUser.ClientId = clientUserDto.clientId;
                clientUser.Client = MapperClients.DtoToEntity(clientUserDto.client);
                clientUser.FirstName = clientUserDto.firstName;
                clientUser.LastName = clientUserDto.lastName;
                clientUser.Email = clientUserDto.email;
                clientUser.Phone = clientUserDto.password;
            }
            return clientUser;
        }

        public static List<ClientUserDto> EntitiesToDtos(List<ClientUser> clientUsers)
        {
            List<ClientUserDto> clientUsersDto = new List<ClientUserDto>();

            foreach (var clientUser in clientUsers)
            {
                clientUsersDto.Add(EntityToDto(clientUser));
            }
            return clientUsersDto;
        }

        public static List<ClientUser> DtosToEntities(List<ClientUserDto> clientUsersDto)
        {
            List<ClientUser> clientUsers = new List<ClientUser>();

            foreach (var clientUserDto in clientUsersDto)
            {
                clientUsers.Add(DtoToEntity(clientUserDto));
            }
            return clientUsers;
        }
    }
}
