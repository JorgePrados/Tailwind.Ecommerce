using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperOrderStates
    {
        public static OrderStateDto EntityToDto(OrderState orderState)
        {
            OrderStateDto orderStateDto = new OrderStateDto();
            if (orderState != null)
            {
                orderStateDto.orderStateId = orderState.Id;
                orderStateDto.description = orderState.Description;
            }
            return orderStateDto;
        }

        public static OrderState DtoToEntity(OrderStateDto orderStateDto)
        {
            OrderState orderState = new OrderState();
            if (orderStateDto != null)
            {
                orderState.Id = orderStateDto.orderStateId;
                orderState.Description = orderStateDto.description;
            }
            return orderState;
        }

        public static List<OrderStateDto> EntitiesToDtos(List<OrderState> orderStates)
        {
            List<OrderStateDto> orderStatesDto = new List<OrderStateDto>();

            foreach (var orderState in orderStates)
            {
                orderStatesDto.Add(EntityToDto(orderState));
            }
            return orderStatesDto;
        }

        public static List<OrderState> DtosToEntities(List<OrderStateDto> orderStatesDto)
        {
            List<OrderState> orderStates = new List<OrderState>();

            foreach (var orderStateDto in orderStatesDto)
            {
                orderStates.Add(DtoToEntity(orderStateDto));
            }
            return orderStates;
        }
    }
}
