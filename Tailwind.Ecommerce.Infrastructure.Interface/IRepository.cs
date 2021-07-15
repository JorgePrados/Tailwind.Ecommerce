using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tailwind.Ecommerce.Infrastructure.Interface
{
    public interface IRepository<T> where T: class
    {
        public int rowCounts { get; set; }
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll(string where = "", object parameters = null, string orderBy = "Id asc", int page = 1, int rowPage = 25);
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
