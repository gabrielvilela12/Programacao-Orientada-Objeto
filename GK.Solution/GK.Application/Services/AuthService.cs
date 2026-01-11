using Application.Interfaces;
using Domain.Interfaces;
using GK.Domain.Entities;

namespace GK.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Usuario?> AutenticarAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);

            if (usuario == null) 
                return null;

            bool senhaValida = _passwordHasher.Verify(usuario.SenhaHash, senha);

            if (!senhaValida)
                return null;

            return usuario;
        }
    }
}
