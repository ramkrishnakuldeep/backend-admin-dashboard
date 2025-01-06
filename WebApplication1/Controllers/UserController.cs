using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Dtos.User;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            var userDto = users.Select(u => u.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto user)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Name = user.Name;
            userModel.Password = user.Password;
            userModel.Username = user.Username;

            _context.SaveChanges();

            return Ok(userModel.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDTO();

            await _context.Users.AddAsync(userModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id) {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(userModel == null) {
                return NotFound();
            }
            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}