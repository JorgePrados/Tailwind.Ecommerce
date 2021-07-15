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
    public class ConfigurationTableRepository : BaseRepository<ConfigurationTable>, IConfigurationTableRepository
    {
        public ConfigurationTableRepository(IConnectionFactory _connectionFactory) : base(_connectionFactory, "ConfigurationTables")
        {
        }

        public async Task<int> DeleteByTableId(int tableId, int userId)
        {
            var sql = $"DELETE FROM {tableName} WHERE TableId = @tableId and UserId = @userId";

            using (var connection = _connectionFactory.GetConnection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { tableId = tableId, userId = userId });

                return affectedRows;
            }
        }
    }
}
