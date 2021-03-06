using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Dimensions { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }
        public string tags { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }

        public Product Product { get; set; }
    }
}
