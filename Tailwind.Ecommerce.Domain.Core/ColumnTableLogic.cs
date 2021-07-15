using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;
using System.Linq;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class ColumnTableLogic : IColumnTableLogic
    {
        private readonly IColumnTableRepository _ColumnTableRepository;
        private readonly IConfigurationTableRepository _ConfigurationTableRepository;

        public ColumnTableLogic(IColumnTableRepository ColumnTableRepository, IConfigurationTableRepository ConfigurationTableRepository)
        {
            _ColumnTableRepository = ColumnTableRepository;
            _ConfigurationTableRepository = ConfigurationTableRepository;
        }
        public async Task<IEnumerable<ColumnTable>> GetColumnTableByUserId(int userId, int tableId)
        {
            string configurationWhere = "TableId = @tableId and UserId = @userId";
            object parameters = new { tableId = tableId, userId = userId };

            var configurationTable = (await _ConfigurationTableRepository.GetAll(configurationWhere, parameters)).Select(x => x.ColumnId);

            var columns = (await _ColumnTableRepository.GetAll()).Where(x => configurationTable.Contains(x.Id));

            return columns;
        }
    }
}
