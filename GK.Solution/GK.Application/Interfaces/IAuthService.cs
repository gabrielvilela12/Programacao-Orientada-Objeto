using GK.Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        // Define que quem implementar isso DEVE ter esse método
        Task<Usuario?> AutenticarAsync(string email, string senha);
    }
}