using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    [Index(nameof(Module), nameof(Role), IsUnique = true)]
    public class Permissions
    {
        public int Id { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public required Roles Role { get; set; }
        [ForeignKey("Modules")]
        public int ModuleId { get; set; }
        public required Modules Module { get; set; }
        public bool IsCreate { get; set; } = true;
        public bool IsRead { get; set; } = true;
        public bool IsDelete { get; set; } = true;
        public bool IsEdit { get; set; } = true;

    }
}