using System;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class ClientDto
    {
        public int clientId { get; set; }
        public string name { get; set; }
        public string businessName { get; set; }
        public string cif { get; set; }
        public string description { get; set; }
        public string contactPerson { get; set; }
        public string contactPerson2 { get; set; }
        public string contactEmail { get; set; }
        public string contactEmail2 { get; set; }
        public string contactPhone { get; set; }
        public string contactPhone2 { get; set; }
        public bool looked { get; set; }
    }
}
