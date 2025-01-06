using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Module;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class ModuleMapper
    {
        public static ModuleDto ToModuleDto(this Modules modules) {
            return new ModuleDto {
                Id = modules.Id,
                Name = modules.Name,
            };
        }

        public static Modules ToModuleFromCreateDTO(this CreateModuleDto modules) {
            return new Modules {
                Name = modules.Name
            };
        }
    }
}