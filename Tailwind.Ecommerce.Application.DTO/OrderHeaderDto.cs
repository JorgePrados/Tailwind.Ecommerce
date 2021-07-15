using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class OrderHeaderDto
    {
        public int orderHeaderId { get; set; }
        public int clientId { get; set; }
        public int userClientId { get; set; }
        public int orderStateId { get; set; }

        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }

        public ClientDto client { get; set; }
        public ClientUserDto clientUser { get; set; }
        public OrderStateDto orderState { get; set; }

    }
}
