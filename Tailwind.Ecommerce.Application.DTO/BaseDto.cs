using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.Application.DTO
{
    public abstract class BaseDto
    {
        public int page { get; set; }
        public int rowCounts { get; set; }
        public string orderBy { get; set; }
        public string search { get; set; }
        public List<string> columnTables { get; set; }
    }
}
