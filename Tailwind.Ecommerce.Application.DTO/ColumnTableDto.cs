using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public class ColumnTableDto
    {
        public int columnTableId { get; set; }
        public int tableId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Boolean isSelected { get; set; }
        public int order { get; set; }
    }
}
