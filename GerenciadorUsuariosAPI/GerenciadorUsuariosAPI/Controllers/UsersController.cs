using GerenciadorUsuariosAPI.Models.DTOs;
using GerenciadorUsuariosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using GerenciadorUsuariosAPI.Data;

namespace GerenciadorUsuariosAPI.Controllers
{
    /// <summary>
    /// Controlador responsável por receber requisições HTTP relacionadas a usuários.
    /// Ele apenas orquestra a chamada ao serviço e devolve respostas HTTP apropriadas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersServices _userService = new UsersServices();

        #region GET

        /// <summary>
        /// Retorna uma lista de usuários com filtros opcionais por nome e status.
        /// </summary>
        [HttpGet("/list")]
        public IActionResult ListUsers([FromQuery] string? userName, [FromQuery] bool? isActive)
        {
            var users = _userService.List(userName, isActive);

            if (users == null)
                return NotFound(new { message = "Nenhum usuário encontrado." });

            return Ok(users);
        }

        /// <summary>
        /// Retorna detalhes de um usuário específico a partir do ID.
        /// </summary>
        [HttpGet("/details/{id}")]
        public IActionResult GetDetails(int id)
        {
            var user = InMemoryDatabase.GetById(id);

            if (user == null) return NotFound(new { message = "Usuário não encontrado." });

            return Ok(new UserResponseDto(user));
        }

        #endregion

        #region POST

        /// <summary>
        /// Registra um novo usuário.
        /// </summary>
        [HttpPost("/register")]
        public IActionResult RegisterUser([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var result = _userService.Register(dto.Username, dto.Password, dto.ConfirmPassword);
                return Created($"/users/details/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Realiza login de um usuário com autenticação básica.
        /// </summary>
        [HttpPost("/login")]
        public IActionResult LoginUser([FromBody] AuthRequestDto dto)
        {
            try
            {
                var result = _userService.Login(dto.Username, dto.Password);
                return Ok($"Login realizado com sucesso, {result.Username}!");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        #endregion

        #region PUT

        /// <summary>
        /// Ativa uma conta de usuário, mediante autenticação do solicitante.
        /// </summary>
        [HttpPut("/active/{id}")]
        public IActionResult ActivateUser(int id, [FromBody] AuthRequestDto authDto)
        {
            try
            {
                var result = _userService.Activate(id, authDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Desativa uma conta de usuário, mediante autenticação do solicitante.
        /// </summary>
        [HttpPut("/desactive/{id}")]
        public IActionResult DeactivateUser(int id, [FromBody] AuthRequestDto authDto)
        {
            try
            {
                var result = _userService.Deactivate(id, authDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Exclui um usuário definitivamente, após validação de autorização.
        /// </summary>
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteUser(int id, [FromBody] AuthRequestDto authDto)
        {
            try
            {
                _userService.Delete(id, authDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        #endregion
    }
}
