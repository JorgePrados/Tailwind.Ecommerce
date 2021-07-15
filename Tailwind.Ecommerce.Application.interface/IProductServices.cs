using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.CrossCutting.Common;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IProductServices
    {
        Task<Response<int>> Add(ProductDto product);
        Task<int> Delete(int id);
        Task<Response<ProductDto>> Get(int id);
        Task<ResponseGridView<IEnumerable<ProductDto>>> GetAll(ProductDto product);
        Task<Response<int>> Update(ProductDto product);
        Task<Response<int>> Save(ProductDto product);
    }
}
