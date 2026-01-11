using Application.Interfaces;
using GK.Application.DTOs;
using GK.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GK.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View("Index");

            var usuario = await _authService.AutenticarAsync(loginDto.Email, loginDto.Senha);

           
        }
    }
}
