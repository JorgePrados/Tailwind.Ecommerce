using System;
using System.Collections.Generic;
using System.Text;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Domain.Entity;

namespace Tailwind.Ecommerce.CrossCutting.Mapper
{
    public class MapperConfigurationTable
    {
        public static ConfigurationTableDto EntityToDto(ConfigurationTable configurationTable)
        {
            ConfigurationTableDto configurationTableDto = new ConfigurationTableDto();
            if (configurationTable != null)
            {
                configurationTableDto.configurationTableId = configurationTable.Id;
                configurationTableDto.tableId = configurationTable.TableId;
                configurationTableDto.columnId = configurationTable.ColumnId;
                configurationTableDto.order = configurationTable.Order;
            }
            return configurationTableDto;
        }

        public static ConfigurationTable DtoToEntity(ConfigurationTableDto configurationTableDto)
        {
            ConfigurationTable configurationTable = new ConfigurationTable();
            if (configurationTableDto != null)
            {
                configurationTable.Id = configurationTableDto.configurationTableId;
                configurationTable.TableId = configurationTableDto.tableId;  
                configurationTable.ColumnId = configurationTableDto.columnId;
                configurationTable.Order = configurationTableDto.order;
                
            }
            return configurationTable;
        }

        public static List<ConfigurationTableDto> EntitiesToDtos(List<ConfigurationTable> configurationTables)
        {
            List<ConfigurationTableDto> configurationTablesDto = new List<ConfigurationTableDto>();

            foreach (var configurationTable in configurationTables)
            {
                configurationTablesDto.Add(EntityToDto(configurationTable));
            }
            return configurationTablesDto;
        }

        public static List<ConfigurationTable> DtosToEntities(List<ConfigurationTableDto> configurationTablesDto)
        {
            List<ConfigurationTable> configurationTables = new List<ConfigurationTable>();

            foreach (var configurationTableDto in configurationTablesDto)
            {
                configurationTables.Add(DtoToEntity(configurationTableDto));
            }
            return configurationTables;
        }
    }
}
