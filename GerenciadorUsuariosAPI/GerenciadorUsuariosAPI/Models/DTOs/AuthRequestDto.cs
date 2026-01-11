using System.ComponentModel.DataAnnotations;

namespace GerenciadorUsuariosAPI.Models.DTOs
{
    public class AuthRequestDto
    {
        //Modelo utilizado para autentificar o usuário que estão tentando realizar uma ação

        [Required(ErrorMessage = "O nome do usuário é obrigatório para autorizar a ação")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória para autorizar a ação")]
        public string Password { get; set; }
    }
}
