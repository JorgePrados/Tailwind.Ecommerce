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
    public class PaymentMethodLogic : IPaymentMethodLogic
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodLogic(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<int> Add(PaymentMethod paymentMethod)
        {
            var result = (await _paymentMethodRepository.Add(paymentMethod));

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = (await _paymentMethodRepository.Delete(id));

            return result;
        }

        public async Task<PaymentMethod> Get(int id)
        {
            var paymentMethod = (await _paymentMethodRepository.Get(id));

            return paymentMethod;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            var paymentMethods = (await _paymentMethodRepository.GetAll());

            return paymentMethods;
        }

        public async Task<int> Update(PaymentMethod user)
        {
            var result = (await _paymentMethodRepository.Update(user));

            return result;
        }
    }
}
