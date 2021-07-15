using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.Domain.Interface
{
    public interface IColumnTableLogic
    {
        Task<IEnumerable<ColumnTable>> GetColumnTableByUserId(int userId, int tableId);
    }
}
