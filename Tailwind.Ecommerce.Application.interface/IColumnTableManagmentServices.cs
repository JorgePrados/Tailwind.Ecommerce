using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.CrossCutting.Common;

namespace Tailwind.Ecommerce.Application.Interface
{
    public interface IColumnTableManagmentServices
    {
        Task<Response<List<ColumnTableDto>>> GetColumnsTable(int userId, int tableId);

        Task<Response<int>> AddConfigurationColumnsTable(List<ColumnTableDto> columnTableDtos, int userId);
    }
}
