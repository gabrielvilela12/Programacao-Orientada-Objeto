using Teste_Solo.Model;

namespace Teste_Solo.Infrastructure.Repositories
{
    public interface ICartaoCreditoRepository
    {
        Task AddCartaoCredito(CartaoCredito cartaoCredito);
        Task <CartaoCredito?> GetById(int? id);
        Task <List<CartaoCredito>> GetAll();
    }
}
