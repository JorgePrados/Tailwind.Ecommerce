using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Linq;

namespace Tailwind.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConnectionFactory _connectionFactory) : base(_connectionFactory, "Users")
        {
        }
    }
}
