using GK.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        // Usamos Task para ser assíncrono (async/await)
        Task<Usuario?> GetByEmailAsync(string email);
    }
}