using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoryServices(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        public async Task<int> Add(CategoryDto categoryDto)
        {
            var category = MapperCategories.DtoToEntity(categoryDto);
            var result = (await _categoryLogic.Add(category));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _categoryLogic.Delete(id));

            return result;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var user = (await _categoryLogic.Get(id));

            return MapperCategories.EntityToDto(user); ;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = (await _categoryLogic.GetAll());

            return MapperCategories.EntitiesToDtos(categories.ToList());
        }

        public async Task<int> Update(CategoryDto categoryDto)
        {
            Category category = MapperCategories.DtoToEntity(categoryDto);

            int result = (await _categoryLogic.Update(category));

            return result;
        }
    }
}
