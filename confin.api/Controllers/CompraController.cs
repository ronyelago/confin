using AutoMapper;
using confin.api.models;
using confin.data.Repositories;
using confin.domain;
using Microsoft.AspNetCore.Mvc;

namespace confin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraRepository _compraRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public CompraController(CompraRepository compraRepository
            ,IMapper mapper
            ,ILogger logger)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
            _logger = logger;
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
        public async Task<IActionResult> Post([FromBody] NovaCompraModel compraModel)
        {
            try
            {
                await _compraRepository.Save(_mapper.Map<Compra>(compraModel));

                return Created("", compraModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}; {ex.InnerException?.Message}");
            }
        }
    }
}
