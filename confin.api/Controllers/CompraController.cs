using AutoMapper;
using confin.api.interfaces.repositories;
using confin.api.models;
using Confin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;

namespace confin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompraController : ControllerBase
{
    private readonly ICompraRepository _compraRepository;
    private readonly ILogger<CompraController> _logger;
    private IMapper _mapper;

    public CompraController(ICompraRepository compraRepository ,IMapper mapper ,ILogger<CompraController> logger)
    {
        _compraRepository = compraRepository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("ObterTodasCompras")]
    public async Task<IActionResult> Get()
    {
        Log.Information("=> Obtendo todas as compras...");
        var compras = await _compraRepository.GetAllAsync();

        return Ok(compras);
    }

    [HttpPost("NovaCompra")]
    public async Task<IActionResult> Post([FromBody] NovaCompraModel compraModel)
    {
        await _compraRepository.AddAsync(_mapper.Map<Compra>(compraModel));

        return Created("", compraModel);
    }
}
