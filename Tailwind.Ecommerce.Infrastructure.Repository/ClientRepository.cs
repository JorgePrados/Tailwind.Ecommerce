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
    public class ClientRepository: IClientRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClientRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> Add(Client entity)
        {
            var sql = "INSERT INTO Clients (Id, Name) VALUES (@Id, @Name)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql,entity);

                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Clients WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }

        public async Task<Client> Get(int id)
        {
            var sql = "SELECT * FROM Clients WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.QueryAsync<Client>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var sql = "SELECT * FROM Clients";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = await connection.QueryAsync<Client>(sql);

                return result;
            }
        }

        public async Task<int> Update(Client entity)
        {
            var sql = "UPDATE Clients SET Name = @Name WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);

                return affectedRows;
            }
        }
    }
}
