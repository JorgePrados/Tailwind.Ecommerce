using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface ICategoryLogic
    {
        Task<int> Add(Category category);
        Task<int> Delete(int id);
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<int> Update(Category category);
    }
}
