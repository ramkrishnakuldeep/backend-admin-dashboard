using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Modules
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
    }
}