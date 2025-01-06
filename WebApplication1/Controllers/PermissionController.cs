using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PermissionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permisisons = await _context.Permissions.ToListAsync();
            var permisisonsDto =  permisisons.GroupBy(u => u.RoleId);
            return Ok(permisisonsDto);
        }
        
    }
}