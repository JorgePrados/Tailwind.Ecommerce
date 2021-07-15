using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperColumnTable
    {
        public static ColumnTableDto EntityToDto(ColumnTable columnTable)
        {
            ColumnTableDto columnTableDto = new ColumnTableDto();
            if (columnTable != null)
            {
                columnTableDto.columnTableId = columnTable.Id;
                columnTableDto.name = columnTable.Name;
                columnTableDto.description = columnTable.Description;
                columnTableDto.tableId = columnTable.TableId;
            }
            return columnTableDto;
        }

        public static ColumnTable DtoToEntity(ColumnTableDto columnTableDto)
        {
            ColumnTable columnTable = new ColumnTable();
            if (columnTableDto != null)
            {
                columnTable.Id = columnTableDto.columnTableId;
                columnTable.Name = columnTableDto.name;
                columnTable.Description = columnTable.Description;
                columnTable.TableId = columnTableDto.tableId;
            }
            return columnTable;
        }

        public static List<ColumnTableDto> EntitiesToDtos(List<ColumnTable> columnTables)
        {
            List<ColumnTableDto> columnTablesDto = new List<ColumnTableDto>();

            foreach (var columnTable in columnTables)
            {
                columnTablesDto.Add(EntityToDto(columnTable));
            }
            return columnTablesDto;
        }

        public static List<ColumnTable> DtosToEntities(List<ColumnTableDto> columnTablesDto)
        {
            List<ColumnTable> columnTables = new List<ColumnTable>();

            foreach (var columnTableDto in columnTablesDto)
            {
                columnTables.Add(DtoToEntity(columnTableDto));
            }
            return columnTables;
        }
    }
}
