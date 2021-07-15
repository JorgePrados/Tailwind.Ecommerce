using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.CrossCutting.Common;

namespace Tailwind.Ecommerce.Infrastructure.Repository
{
    public abstract class BaseRepository<T>
    {
        protected string tableName;
        protected readonly IConnectionFactory _connectionFactory;
        public BaseRepository(IConnectionFactory connectionFactory, string tableName)
        {
            _connectionFactory = connectionFactory;
            this.tableName = tableName;
        }
        public int rowCounts { get; set; }
        public async Task<int> Add(T entity)
        {
            string fields = "";
            string values = "";
            var sql = $"INSERT INTO {tableName}";

            var properties = entity.GetType().GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.FullName.Contains("Tailwind")).Select(x => x.Name);
            foreach (var property in properties)
            {
                fields += $" [{property}],";
                values += $" @{property},";
            }
            fields = fields.Remove(fields.Length - 1);
            values = values.Remove(values.Length - 1);


            sql += $" ({fields}) VALUES (values)";

            using (var connection = _connectionFactory.GetConnection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, entity);

                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = $"DELETE FROM {tableName} WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }

        public async Task<T> Get(int id)
        {
            var sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = await connection.QueryAsync<T>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<T>> GetAll(string where = "", object parameters = null, string orderBy = "Id asc", int page = 0, int rowPage = 25)
        {

            IEnumerable<T> result = new T[] { };

            string pagination = "";
            if (page > 0)
                pagination = $"OFFSET {(page - 1) * rowPage}  ROWS FETCH NEXT {rowPage} ROWS ONLY";

            string orberBy = $"order by {orderBy}";
            if (!string.IsNullOrEmpty(where))
            {
                where = "where " + where;
            }

            var sql = $"SELECT * FROM {tableName} {where} {orberBy} {pagination}";
            var sqlCount = $"SELECT COUNT(Id) FROM {tableName} {where}";

            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    this.rowCounts = connection.QueryFirst<int>(sqlCount, parameters);
                    if (this.rowCounts > 0)
                    {
                        result = await connection.QueryAsync<T>(sql, parameters);
                    }
                    return result;

                }
                catch (Exception e)
                {
                    return result;
                }
            }
        }

        public async Task<int> Update(T entity)
        {
            var sql = $"UPDATE {tableName} SET";

            var properties = entity.GetType().GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.FullName.Contains("Tailwind")).Select(x => x.Name);// && x.PropertyType.BaseType.Name != "Object");
            foreach (var property in properties)
            {
                sql += $" [{property}] = @{property},";
            }
            sql = sql.Remove(sql.Length - 1);

            sql += " WHERE Id = @Id";

            using (var connection = _connectionFactory.GetConnection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, entity);

                return affectedRows;
            }
        }
    }
}
