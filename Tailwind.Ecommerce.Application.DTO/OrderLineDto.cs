using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class OrderLineDto
    {
        public int orderLineId { get; set; }
        public int productId { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public decimal price { get; set; }
        public decimal dimensions { get; set; }
        public decimal weight { get; set; }
        public decimal discount { get; set; }
        public string tags { get; set; }
        public int categoryId { get; set; }
        public decimal amount { get; set; }

        public ProductDto product { get; set; }
    }
}
