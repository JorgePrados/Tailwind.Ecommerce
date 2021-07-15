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
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Add(Category category)
        {
            var result = (await _categoryRepository.Add(category));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _categoryRepository.Delete(id));

            return result;
        }

        public async Task<Category> Get(int id)
        {
            var category = (await _categoryRepository.Get(id));

            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = (await _categoryRepository.GetAll());

            return categories;
        }

        public async Task<int> Update(Category category)
        {
            var result = (await _categoryRepository.Update(category));

            return result;
        }
    }
}
