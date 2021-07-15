using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class ClientUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
