using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    [Index(nameof(User), nameof(Role), IsUnique = true)]
    public class UserRoles
    {
        public int Id { get; set; }
        
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public required Roles Role{ get; set; }
        
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public required Users User{ get; set; }
    }
}