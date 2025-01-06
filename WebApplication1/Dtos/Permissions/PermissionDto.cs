using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos.Permissions
{
    public class PermissionDto
    {
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelete { get; set; }
        public bool IsEdit { get; set; }
    }
}