using Microsoft.AspNetCore.Mvc;
using Teste_Solo.Infrastructure.Repositories;
using Teste_Solo.Model;

namespace Teste_Solo.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CartaoCreditoApiController : ControllerBase
        {
            private readonly ICartaoCreditoRepository _cartaoCreditoRepository;
            public CartaoCreditoApiController(ICartaoCreditoRepository cartaoCreditoRepository)
            {
                _cartaoCreditoRepository = cartaoCreditoRepository;
            }

            [HttpPost]
            public async Task<IActionResult> CreateCartaoCredito([FromBody] CartaoCredito cartaoCredito)
            {
                await _cartaoCreditoRepository.AddCartaoCredito(cartaoCredito);
                return CreatedAtAction(nameof(GetCartaoCreditoById), cartaoCredito);
            }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetCartaoCreditoById(int id)
            {
                var cartaoCredito = await _cartaoCreditoRepository.GetById(id);
                if (cartaoCredito == null)
                {
                    return NotFound();
                }
                return Ok(cartaoCredito);
            }
            [HttpGet]
            public async Task<IActionResult> GetAllCartoesCredito()
            {
                var cartoesCredito = await _cartaoCreditoRepository.GetAll();
                return Ok(cartoesCredito);
            }
        }
   
            
        }

