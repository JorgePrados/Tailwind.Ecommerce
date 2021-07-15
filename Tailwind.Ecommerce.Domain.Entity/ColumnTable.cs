using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class ColumnTable
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
