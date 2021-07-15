using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperTable
    {
        public static TableDto EntityToDto(Table table)
        {
            TableDto tableDto = new TableDto();
            if (table != null)
            {
                tableDto.tableId = table.Id;
                tableDto.name = table.Name;
                tableDto.description = table.Description;
            }
            return tableDto;
        }

        public static Table DtoToEntity(TableDto tableDto)
        {
            Table table = new Table();
            if (tableDto != null)
            {
                table.Id = tableDto.tableId;
                table.Name = tableDto.name;
                table.Description = tableDto.description;
            }
            return table;
        }

        public static List<TableDto> EntitiesToDtos(List<Table> tables)
        {
            List<TableDto> tablesDto = new List<TableDto>();

            foreach (var table in tables)
            {
                tablesDto.Add(EntityToDto(table));
            }
            return tablesDto;
        }

        public static List<Table> DtosToEntities(List<TableDto> tablesDto)
        {
            List<Table> tables = new List<Table>();

            foreach (var tableDto in tablesDto)
            {
                tables.Add(DtoToEntity(tableDto));
            }
            return tables;
        }
    }
}
