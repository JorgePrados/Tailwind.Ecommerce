using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class PaymentMethodDto
    {
        public int paymentMethodId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
