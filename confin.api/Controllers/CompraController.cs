using confin.data.Repositories;
using confin.domain;
using Microsoft.AspNetCore.Mvc;

namespace Finacon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraRepository _compraRepository;

        public CompraController(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet("ObterTodasCompras")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var compras = await _compraRepository.Get();

                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}; {ex.InnerException?.Message}"); 
            }
        }

        [HttpPost("NovaCompra")]
        public async Task<IActionResult> Post([FromBody] Compra compra)
        {
            try
            {
                await _compraRepository.Save(compra);

                return Created("", compra);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}; {ex.InnerException?.Message}");
            }
        }
    }
}
