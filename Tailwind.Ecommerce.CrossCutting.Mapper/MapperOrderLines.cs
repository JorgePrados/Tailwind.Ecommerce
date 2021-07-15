using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperOrderLines
    {
        public static OrderLineDto EntityToDto(OrderLine orderLine)
        {
            OrderLineDto orderLineDto = new OrderLineDto();
            if (orderLine != null)
            {
                orderLineDto.orderLineId = orderLine.Id;
                orderLineDto.productId = orderLine.ProductId;
                orderLineDto.name = orderLine.Name;
                orderLineDto.shortDescription = orderLine.ShortDescription;
                orderLineDto.longDescription = orderLine.LongDescription;
                orderLineDto.price = orderLine.Price;
                orderLineDto.dimensions = orderLine.Dimensions;
                orderLineDto.weight = orderLine.Weight;
                orderLineDto.discount = orderLine.Discount;
                orderLineDto.tags = orderLine.tags;
                orderLineDto.categoryId = orderLine.CategoryId;
                orderLineDto.amount = orderLine.Amount;
                orderLineDto.product = MapperProducts.EntityToDto(orderLine.Product);

            }
            return orderLineDto;
        }

        public static OrderLine DtoToEntity(OrderLineDto orderLineDto)
        {
            OrderLine orderLine = new OrderLine();
            if (orderLineDto != null)
            {
                orderLine.Id = orderLineDto.orderLineId;
                orderLine.ProductId = orderLineDto.productId;
                orderLine.Name = orderLineDto.name;
                orderLine.ShortDescription = orderLineDto.shortDescription;
                orderLine.LongDescription = orderLineDto.longDescription;
                orderLine.Price = orderLineDto.price;
                orderLine.Dimensions = orderLineDto.dimensions;
                orderLine.Weight = orderLineDto.weight;
                orderLine.Discount = orderLineDto.discount;
                orderLine.tags = orderLineDto.tags;
                orderLine.CategoryId = orderLineDto.categoryId;
                orderLine.Amount = orderLineDto.amount;
                orderLine.Product = MapperProducts.DtoToEntity(orderLineDto.product);
            }
            return orderLine;
        }

        public static List<OrderLineDto> EntitiesToDtos(List<OrderLine> orderLines)
        {
            List<OrderLineDto> orderLinesDto = new List<OrderLineDto>();

            foreach (var orderLine in orderLines)
            {
                orderLinesDto.Add(EntityToDto(orderLine));
            }
            return orderLinesDto;
        }

        public static List<OrderLine> DtosToEntities(List<OrderLineDto> orderLinesDto)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            foreach (var orderLineDto in orderLinesDto)
            {
                orderLines.Add(DtoToEntity(orderLineDto));
            }
            return orderLines;
        }
    }
}
