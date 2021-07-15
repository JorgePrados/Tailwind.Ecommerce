using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Interface;

namespace Tailwind.Ecommerce.Domain.Core
{
    public class ProductLogic : IProductLogic
    {
        public int rowCounts { get; set; }

        private readonly IProductRepository _productRepository;
        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Add(Product product)
        {
            var result = (await _productRepository.Add(product));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _productRepository.Delete(id));

            return result;
        }

        public async Task<Product> Get(int id)
        {
            var product = (await _productRepository.Get(id));

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll(Product filters, int page, string search = null, string orderBy = "Id asc")
        {
            string where = "";
            int rowPage = 25;

            object parameters = new { search = search };

            if (!string.IsNullOrEmpty(search))
            {
                
                where = "Code like '%' + @search + '%' OR Name like '%' + @search + '%' OR ShortDescription like '%' + @search + '%' OR LongDescription like '%' + @search + '%'";
            }

            var products = (await _productRepository.GetAll(where, parameters , orderBy, page, rowPage));

            this.rowCounts = _productRepository.rowCounts;
            

            return products;
        }

        public async Task<int> Update(Product product)
        {
            var result = (await _productRepository.Update(product));

            return result;
        }
    }
}
