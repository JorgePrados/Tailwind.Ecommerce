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
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> Add(User entity)
        {
            var sql = "INSERT INTO Users (UserCode, FirstName, LastName, UserName, Password) VALUES (@UserCode, @FirstName, @LastName, @UserName, @Password)";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);

                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }

        public async Task<User> Get(int id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = "SELECT * FROM Users";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = await connection.QueryAsync<User>(sql);

                return result;
            }
        }

        public async Task<int> Update(User entity)
        {
            var sql = "UPDATE Users SET UserCode = @UserCode, FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);

                return affectedRows;
            }
        }
    }
}
