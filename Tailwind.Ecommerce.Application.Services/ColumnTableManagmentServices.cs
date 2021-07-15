using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.CrossCutting.Mapper;
using Tailwind.Ecommerce.Domain.Entity;
using Tailwind.Ecommerce.Domain.Interface;

namespace Tailwind.Ecommerce.Application.Services
{
    public class ColumnTableManagmentServices: IColumnTableManagmentServices
    {
        private readonly IColumnTableManagmentLogic _columnTableManagmentLogic;
        public ColumnTableManagmentServices(IColumnTableManagmentLogic columnTableManagmentLogic)
        {
            _columnTableManagmentLogic = columnTableManagmentLogic;
        }

        public async Task<Response<List<ColumnTableDto>>> GetColumnsTable(int userId, int tableId) 
        {
            Response<List<ColumnTableDto>> response = new Response<List<ColumnTableDto>>();

            var columnsTable = await _columnTableManagmentLogic.GetColumnsTable(tableId);
            var configurationTable = await _columnTableManagmentLogic.GetConfigurationTable(userId,tableId);

            var columnsTableDto = MapperColumnTable.EntitiesToDtos(columnsTable);

            var configurationTableColumnId = configurationTable.Select(x => x.ColumnId);

            foreach(var columnTable in columnsTableDto)
            {
                columnTable.isSelected = configurationTableColumnId.Contains(columnTable.columnTableId);
                columnTable.order = configurationTable.Where(x => x.ColumnId == columnTable.columnTableId && x.TableId == columnTable.tableId && x.UserId == userId)
                                     .Select(x => x.Order).FirstOrDefault();
            }
            columnsTableDto = columnsTableDto.OrderBy(x => x.order).ToList();
            response.codeMessage = 200;
            response.isSuccess = true;

            response.data = columnsTableDto;
            
            return response;
        }

        public async Task<Response<int>> AddConfigurationColumnsTable(List<ColumnTableDto> columnTableDtos, int userId)
        {
            Response<int> response = new Response<int>();

            response.codeMessage = 200;
            response.isSuccess = true;

            List<ConfigurationTable> configurationsTable = new List<ConfigurationTable>();

            foreach(var columnTableDto in columnTableDtos)
            {
                ConfigurationTable configurationTable = new ConfigurationTable();
                configurationTable.ColumnId = columnTableDto.columnTableId;
                configurationTable.TableId = columnTableDto.tableId;
                configurationTable.Order = columnTableDto.order;
                configurationTable.UserId = userId;

                configurationsTable.Add(configurationTable);
            }

            response.data = await _columnTableManagmentLogic.AddConfigurationColumnsTable(configurationsTable);

            return response;
        }
    }
}
