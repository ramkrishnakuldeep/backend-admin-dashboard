using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Permissions;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class PermissionMapper
    {
        public static PermissionDto ToPermissionDto(this Permissions permission)
        {
            return new PermissionDto
            {
                IsCreate = permission.IsCreate,
                IsDelete = permission.IsDelete,
                IsEdit = permission.IsEdit,
                IsRead = permission.IsRead,
            };
        }

    }
}