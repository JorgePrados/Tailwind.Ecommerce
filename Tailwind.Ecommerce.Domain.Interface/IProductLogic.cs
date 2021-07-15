using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IProductLogic
    {
        public int rowCounts { get; set; }

        Task<int> Add(Product product);
        Task<int> Delete(int id);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll(Product filters, int page, string search, string orderBy = "Id asc");
        Task<int> Update(Product product);
    }
}
