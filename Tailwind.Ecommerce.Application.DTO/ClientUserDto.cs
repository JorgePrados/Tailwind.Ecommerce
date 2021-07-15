using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class ClientUserDto
    {
        public int ClientUserId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }

        public int clientId { get; set; }
        public ClientDto client { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
