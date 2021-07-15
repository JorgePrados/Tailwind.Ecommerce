using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperProducts
    {
        public static ProductDto EntityToDto(Product product)
        {
            ProductDto productDto = new ProductDto();
            if (product != null)
            {
                productDto.productId = product.Id;
                productDto.name = product.Name;
                productDto.shortDescription = product.ShortDescription;
                productDto.longDescription = product.LongDescription;
                productDto.price = product.Price;
                productDto.dimensions = product.Dimensions;
                productDto.weight = product.Weight;
                productDto.discount = product.Discount;
                productDto.tags = product.tags;
                productDto.categoryId = product.CategoryId;
                productDto.code = product.Code;
                productDto.category = MapperCategories.EntityToDto(product.Category);
            }
            return productDto;
        }

        public static Product DtoToEntity(ProductDto productDto)
        {
            Product product = new Product();
            if (productDto != null)
            {
                product.Id = productDto.productId;
                product.Code = productDto.code;
                product.Name = productDto.name;
                product.ShortDescription = productDto.shortDescription;
                product.LongDescription = productDto.longDescription;
                product.Price = productDto.price;
                product.Dimensions = productDto.dimensions;
                product.Weight = productDto.weight;
                product.Discount = productDto.discount;
                product.tags = productDto.tags;
                product.CategoryId = productDto.categoryId;
                product.Category = MapperCategories.DtoToEntity(productDto.category);
            }
            return product;
        }

        public static List<ProductDto> EntitiesToDtos(List<Product> products)
        {
            List<ProductDto> productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                productsDto.Add(EntityToDto(product));
            }
            return productsDto;
        }

        public static List<Product> DtosToEntities(List<ProductDto> productsDto)
        {
            List<Product> products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                products.Add(DtoToEntity(productDto));
            }
            return products;
        }
    }
}
