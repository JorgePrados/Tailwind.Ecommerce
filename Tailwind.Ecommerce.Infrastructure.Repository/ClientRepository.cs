using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Linq;

namespace Tailwind.Ecommerce.Infrastructure.Repository
{
    public class ClientRepository: BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(IConnectionFactory _connectionFactory) : base(_connectionFactory, "Clients")
        {
        }
    }
}
