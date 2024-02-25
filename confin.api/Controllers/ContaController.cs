using AutoMapper;
using confin.api.interfaces.repositories;
using confin.api.models;
using Confin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace confin.Controllers;

public class ContaController : ControllerBase
{
    private IMapper _mapper;
    private readonly IContaRepository _contaRepository;

    public ContaController(IMapper mapper, IContaRepository contaRepository)
    {
        _mapper = mapper;
        _contaRepository = contaRepository;
    }

    [HttpGet("ObterTodasContas")]
    public async Task<IActionResult> Get()
    {
        Log.Information("=> Obtendo todas as contas..");
        var compras = await _contaRepository.GetAllAsync();

        return Ok(compras);
    }

    [HttpPost("NovaConta")]
    public async Task<IActionResult> Post([FromBody] NovaContaModel contaModel)
    {
        await _contaRepository.AddAsync(_mapper.Map<Conta>(contaModel));

        return Created("", contaModel);
    }
}