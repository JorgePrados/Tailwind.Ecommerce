using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperOrderHeaders
    {
        public static OrderHeaderDto EntityToDto(OrderHeader orderHeader)
        {

        OrderHeaderDto orderHeaderDto = new OrderHeaderDto();
            if (orderHeaderDto != null)
            {
                orderHeaderDto.orderHeaderId = orderHeader.Id;
                orderHeaderDto.clientId = orderHeader.ClientId;
                orderHeaderDto.userClientId = orderHeader.UserClientId;
                orderHeaderDto.orderStateId = orderHeader.OrderStateId;
                orderHeaderDto.orderDate = orderHeader.OrderDate;
                orderHeaderDto.deliveryDate = orderHeader.DeliveryDate;
                orderHeaderDto.client = MapperClients.EntityToDto(orderHeader.Client);
                orderHeaderDto.clientUser = MapperClientUsers.EntityToDto(orderHeader.ClientUser);
                orderHeaderDto.orderState = MapperOrderStates.EntityToDto(orderHeader.OrderState);
            }
            return orderHeaderDto;
        }

        public static OrderHeader DtoToEntity(OrderHeaderDto orderHeaderDto)
        {
            OrderHeader orderHeader = new OrderHeader();
            if (orderHeaderDto != null)
            {
                orderHeader.Id = orderHeaderDto.orderHeaderId;
                orderHeader.ClientId = orderHeaderDto.clientId;
                orderHeader.UserClientId = orderHeaderDto.userClientId;
                orderHeader.OrderStateId = orderHeaderDto.orderStateId;
                orderHeader.OrderDate = orderHeaderDto.orderDate;
                orderHeader.DeliveryDate = orderHeaderDto.deliveryDate;
                orderHeader.Client = MapperClients.DtoToEntity(orderHeaderDto.client);
                orderHeader.ClientUser = MapperClientUsers.DtoToEntity(orderHeaderDto.clientUser);
                orderHeader.OrderState = MapperOrderStates.DtoToEntity(orderHeaderDto.orderState);
            }
            return orderHeader;
        }

        public static List<OrderHeaderDto> EntitiesToDtos(List<OrderHeader> orderHeaders)
        {
            List<OrderHeaderDto> orderHeadersDto = new List<OrderHeaderDto>();

            foreach (var orderHeader in orderHeaders)
            {
                orderHeadersDto.Add(EntityToDto(orderHeader));
            }
            return orderHeadersDto;
        }

        public static List<OrderHeader> DtosToEntities(List<OrderHeaderDto> orderHeadersDto)
        {
            List<OrderHeader> orderHeaders = new List<OrderHeader>();

            foreach (var orderHeaderDto in orderHeadersDto)
            {
                orderHeaders.Add(DtoToEntity(orderHeaderDto));
            }
            return orderHeaders;
        }
    }
}
