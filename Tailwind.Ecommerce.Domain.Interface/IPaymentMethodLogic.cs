using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IPaymentMethodLogic
    {
        Task<int> Add(PaymentMethod paymentMethod);
        Task<int> Delete(int id);
        Task<PaymentMethod> Get(int id);
        Task<IEnumerable<PaymentMethod>> GetAll();
        Task<int> Update(PaymentMethod paymentMethod);
    }
}
