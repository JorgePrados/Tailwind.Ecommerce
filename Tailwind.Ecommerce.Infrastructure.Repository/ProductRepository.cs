using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Linq;
using System.Reflection;

namespace Tailwind.Ecommerce.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IConnectionFactory _connectionFactory):base(_connectionFactory,"Products")
        {

        }
    }
}
