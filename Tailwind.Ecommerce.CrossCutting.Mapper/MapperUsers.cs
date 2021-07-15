using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperUsers
    {
        public static UserDto EntityToDto(User user)
        {
            UserDto userDto = new UserDto();
            if (user != null)
            {
                userDto.userId = user.Id;
                userDto.userCode = user.UserCode;
                userDto.firstName = user.FirstName;
                userDto.lastName = user.LastName;
                userDto.userName = user.UserName;
                userDto.password = user.Password;
            }
            return userDto;
        }

        public static User DtoToEntity(UserDto userDto)
        {
            User user = new User();
            if (userDto != null)
            {
                user.Id = userDto.userId;
                user.UserCode = userDto.userCode;
                user.FirstName = userDto.firstName;
                user.LastName = userDto.lastName;
                user.UserName = userDto.userName;
                user.Password = userDto.password;
            }
            return user;
        }

        public static List<UserDto> EntitiesToDtos(List<User> users)
        {
            List<UserDto> usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(EntityToDto(user));
            }
            return usersDto;
        }

        public static List<User> DtosToEntities(List<UserDto> usersDto)
        {
            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                users.Add(DtoToEntity(userDto));
            }
            return users;
        }
    }
}
