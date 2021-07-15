using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Infrastructure.Interface
{
    public interface IConfigurationTableRepository : IRepository<ConfigurationTable>
    {
        Task<int> DeleteByTableId(int tableId, int userId);
    }
}
