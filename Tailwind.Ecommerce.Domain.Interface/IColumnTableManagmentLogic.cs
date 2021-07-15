using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IColumnTableManagmentLogic
    {
        Task<List<ColumnTable>> GetColumnsTable(int tableId);
        Task<List<ConfigurationTable>> GetConfigurationTable(int userId, int tableId);
        Task<int> AddConfigurationColumnsTable(List<ConfigurationTable> configurationTables);

    }
}
