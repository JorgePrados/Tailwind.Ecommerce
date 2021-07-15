using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class CategoryDto
    {
        public int categoryId { get; set; }
        public int principalCategoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal discount { get; set; }
        public string tags { get; set; }
    }
}
