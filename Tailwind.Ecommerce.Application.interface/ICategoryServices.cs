using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface ICategoryServices
    {
        Task<int> Add(CategoryDto category);
        Task<int> Delete(int id);
        Task<CategoryDto> Get(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<int> Update(CategoryDto category);
    }
}
