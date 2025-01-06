using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Role;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class RoleMapper
    {

        public static RoleDto ToRoleDto(this Roles roleModel) {
            return new RoleDto {
                Id = roleModel.Id,
                Name = roleModel.Name,
            };
        }

        public static Roles ToRoleFromCreateDTO(this CreateRoleDto roleModel) {
            return new Roles {
                Name = roleModel.Name
            };
        }
        
    }
}