using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IPaymentMethodServices
    {
        Task<int> Add(PaymentMethodDto paymentMethod);
        Task<int> Delete(int id);
        Task<PaymentMethodDto> Get(int id);
        Task<IEnumerable<PaymentMethodDto>> GetAll();
        Task<int> Update(PaymentMethodDto paymentMethod);
    }
}
