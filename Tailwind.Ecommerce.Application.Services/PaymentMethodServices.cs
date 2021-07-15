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
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private readonly IPaymentMethodLogic _paymentMethodLogic;

        public PaymentMethodServices(IPaymentMethodLogic paymentMethodLogic)
        {
            _paymentMethodLogic = paymentMethodLogic;
        }

        public async Task<int> Add(PaymentMethodDto paymentMethodDto)
        {
            var paymentMethod = MapperPaymentMethods.DtoToEntity(paymentMethodDto);
            var result = (await _paymentMethodLogic.Add(paymentMethod));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _paymentMethodLogic.Delete(id));

            return result;
        }

        public async Task<PaymentMethodDto> Get(int id)
        {
            var paymentMethod = (await _paymentMethodLogic.Get(id));

            return MapperPaymentMethods.EntityToDto(paymentMethod); ;
        }

        public async Task<IEnumerable<PaymentMethodDto>> GetAll()
        {
            var paymentMethods = (await _paymentMethodLogic.GetAll());

            return MapperPaymentMethods.EntitiesToDtos(paymentMethods.ToList());
        }

        public async Task<int> Update(PaymentMethodDto paymentMethodDto)
        {
            PaymentMethod paymentMethod = MapperPaymentMethods.DtoToEntity(paymentMethodDto);

            int result = (await _paymentMethodLogic.Update(paymentMethod));

            return result;
        }
    }
}
