using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos.Role
{
    public class RoleDto
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
    }
}