using System;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public string Cif { get; set; }
        public string Description { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPerson2 { get; set; }
        public string ContactEmail { get; set; }
        public string ContactEmail2 { get; set; }
        public string ContactPhone { get; set; }
        public string ContactPhone2 { get; set; }
        public bool Looked { get; set; }
    }
}
