using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos.Role;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RoleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _context.Roles.ToListAsync();
            var roleDto = roles.Select(u => u.ToRoleDto());
            return Ok(roleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto roleDto)
        {
            var roleModel = roleDto.ToRoleFromCreateDTO();

            await _context.Roles.AddAsync(roleModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel.ToRoleDto());
        }
    }
}