using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos.Module;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModuleController: ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ModuleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modules = await _context.Modules.ToListAsync();
            var moduleDto =  modules.Select(u => u.ToModuleDto());
            return Ok(moduleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto roleDto)
        {
            var module = roleDto.ToModuleFromCreateDTO();

            await _context.Modules.AddAsync(module);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = module.Id }, module.ToModuleDto());
        }
        
    }
}