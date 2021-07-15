using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public int PrincipalCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public string tags { get; set; }
        public Category PrincipalCategory { get; set; }
    }
}
