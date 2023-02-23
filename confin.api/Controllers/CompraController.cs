using AutoMapper;
using confin.api.models;
using confin.data.Repositories;
using confin.domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace confin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraRepository _compraRepository;
        private readonly ILogger<CompraController> _logger;
        private IMapper _mapper;

        public CompraController(CompraRepository compraRepository
            ,IMapper mapper
            ,ILogger<CompraController> logger)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("ObterTodasCompras")]
        public async Task<IActionResult> Get()
        {
            Log.Information("*****ObterTodasAsCompras*****");
            var compras = await _compraRepository.Get();

            return Ok(compras);
        }

        [HttpPost("NovaCompra")]
        public async Task<IActionResult> Post([FromBody] NovaCompraModel compraModel)
        {
            await _compraRepository.Save(_mapper.Map<Compra>(compraModel));

            return Created("", compraModel);
        }
    }
}
