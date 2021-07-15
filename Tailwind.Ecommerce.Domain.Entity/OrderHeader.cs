using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserClientId { get; set; }
        public int OrderStateId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Client Client { get; set; }
        public ClientUser ClientUser { get; set; }
        public OrderState OrderState { get; set; }

    }
}
