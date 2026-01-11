using GerenciadorUsuariosAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorUsuariosAPI.Models.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }


        public UserResponseDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            IsActive = user.IsActive;
        }

        public UserResponseDto()
        {

        }
    }
}
