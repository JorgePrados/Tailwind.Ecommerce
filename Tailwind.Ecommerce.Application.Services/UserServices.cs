using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Mapper;
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
    }
}
