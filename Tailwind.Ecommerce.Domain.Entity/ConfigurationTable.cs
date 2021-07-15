using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Domain.Entity
{
    public class ConfigurationTable
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int ColumnId { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }

    }
}
