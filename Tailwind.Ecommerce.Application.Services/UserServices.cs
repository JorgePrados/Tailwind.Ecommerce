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
    public class UserServices : IUserServices
    {
        private readonly IUserLogic _userLogic;

        public UserServices(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public async Task<UserDto> Authenticate(string userName, string password)
        {
            var user = await _userLogic.Authenticate(userName, password);

            return MapperUsers.EntityToDto(user);
        }

        public async Task<int> Add(UserDto userDto)
        {
            var user = MapperUsers.DtoToEntity(userDto);
            var result = (await _userLogic.Add(user));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _userLogic.Delete(id));

            return result;
        }

        public async Task<UserDto> Get(int id)
        {
            var user = (await _userLogic.Get(id));

            return MapperUsers.EntityToDto(user); ;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = (await _userLogic.GetAll());

            return MapperUsers.EntitiesToDtos(users.ToList());
        }

        public async Task<int> Update(UserDto userDto)
        {
            User user = MapperUsers.DtoToEntity(userDto);

            int result = (await _userLogic.Update(user));

            return result;
        }
    }
}
