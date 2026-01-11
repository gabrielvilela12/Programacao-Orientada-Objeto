using Microsoft.EntityFrameworkCore;
using Teste_Solo.Model;

namespace Teste_Solo.Infrastructure.Repositories
{
    public class CartaoCreditoRepository : ICartaoCreditoRepository
    {
        private readonly ApplicationDbContext _context;

        public CartaoCreditoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddCartaoCredito(CartaoCredito cartaoCredito)
        {
             await _context.CartaoCredito.AddAsync(cartaoCredito);
             await  _context.SaveChangesAsync();
        }

        public async Task<List<CartaoCredito>> GetAll()
        {
            return await _context.CartaoCredito.ToListAsync();
        }

        public async Task<CartaoCredito?> GetById(int? id)
        {
           return await _context.CartaoCredito.FindAsync(id);
        }
    }
}
