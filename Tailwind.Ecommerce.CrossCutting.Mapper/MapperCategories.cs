using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperCategories
    {
        public static CategoryDto EntityToDto(Category category)
        {
            CategoryDto categoryDto = new CategoryDto();
            if (category != null)
            {

                categoryDto.categoryId = category.Id;
                categoryDto.principalCategoryId = category.PrincipalCategoryId;
                categoryDto.name = category.Name;
                categoryDto.description = category.Description;
                categoryDto.discount = category.Discount;
                categoryDto.tags = category.tags;
            }
            return categoryDto;
        }

        public static Category DtoToEntity(CategoryDto categoryDto)
        {
            Category category = new Category();
            if (categoryDto != null)
            {
                category.Id = categoryDto.categoryId;
                category.PrincipalCategoryId = categoryDto.principalCategoryId;
                category.Name = categoryDto.name;
                category.Description = categoryDto.description;
                category.Discount = categoryDto.discount;
                category.tags = categoryDto.tags;
            }
            return category;
        }

        public static List<CategoryDto> EntitiesToDtos(List<Category> categories)
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(EntityToDto(category));
            }
            return categoriesDto;
        }

        public static List<Category> DtosToEntities(List<CategoryDto> categoriesDto)
        {
            List<Category> categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                categories.Add(DtoToEntity(categoryDto));
            }
            return categories;
        }
    }
}
