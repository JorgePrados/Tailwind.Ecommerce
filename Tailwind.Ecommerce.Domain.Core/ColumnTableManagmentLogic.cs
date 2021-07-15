using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class ColumnTableManagmentLogic: IColumnTableManagmentLogic
    {
        private readonly IColumnTableRepository _columnTableRepository;
        private readonly IConfigurationTableRepository _configurationTableRepository;
        public ColumnTableManagmentLogic(IColumnTableRepository columnTableRepository, IConfigurationTableRepository configurationTableRepository)
        {
            _columnTableRepository = columnTableRepository;
            _configurationTableRepository = configurationTableRepository;
        }
        public async Task<List<ColumnTable>> GetColumnsTable(int tableId)
        {
            string configurationWhere = "TableId = @tableId";
            object parameters = new { tableId = tableId };

            var result = await _columnTableRepository.GetAll(configurationWhere, parameters);
            return result.ToList();
        }

        public async Task<List<ConfigurationTable>> GetConfigurationTable(int userId, int tableId)
        {
            string configurationWhere = "TableId = @tableId and UserId = @userId";
            object parameters = new { tableId = tableId, userId = userId };

            var result = await _configurationTableRepository.GetAll(configurationWhere, parameters);
            return result.ToList();
        }

        public async Task<int> AddConfigurationColumnsTable(List<ConfigurationTable> configurationTables)
        {
            var result = 0;
            if (configurationTables.Count == 0)
                return 0;

            await _configurationTableRepository.DeleteByTableId(configurationTables[0].TableId, configurationTables[0].UserId);

            foreach (var configurationTable in configurationTables)
            {
                result = await _configurationTableRepository.Add(configurationTable);
            }

            return result;
        }
    }
}
