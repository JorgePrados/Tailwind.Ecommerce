using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperPaymentMethods
    {
        public static PaymentMethodDto EntityToDto(PaymentMethod paymentMethod)
        {
            PaymentMethodDto paymentMethodDto = new PaymentMethodDto();
            if (paymentMethod != null)
            {
                paymentMethodDto.paymentMethodId = paymentMethod.Id;
                paymentMethodDto.name = paymentMethod.Name;
                paymentMethodDto.description = paymentMethod.Description;
            }
            return paymentMethodDto;
        }

        public static PaymentMethod DtoToEntity(PaymentMethodDto paymentMethodDto)
        {
            PaymentMethod paymentMethod = new PaymentMethod();
            if (paymentMethodDto != null)
            {
                paymentMethod.Id = paymentMethodDto.paymentMethodId;
                paymentMethod.Name = paymentMethodDto.name;
                paymentMethod.Description = paymentMethodDto.description;
            }
            return paymentMethod;
        }

        public static List<PaymentMethodDto> EntitiesToDtos(List<PaymentMethod> paymentMethods)
        {
            List<PaymentMethodDto> paymentMethodsDto = new List<PaymentMethodDto>();

            foreach (var paymentMethod in paymentMethods)
            {
                paymentMethodsDto.Add(EntityToDto(paymentMethod));
            }
            return paymentMethodsDto;
        }

        public static List<PaymentMethod> DtosToEntities(List<PaymentMethodDto> paymentMethodsDto)
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            foreach (var paymentMethodDto in paymentMethodsDto)
            {
                paymentMethods.Add(DtoToEntity(paymentMethodDto));
            }
            return paymentMethods;
        }
    }
}
