using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this Users userModel) {
            return new UserDto {
                Id = userModel.Id,
                Name = userModel.Name,
                Username = userModel.Username,
            };
        }

        public static Users ToUserFromCreateDTO(this CreateUserDto userModel) {
            return new Users {
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password,
                Roles = userModel.Roles,
            };
        }
        
    }
}