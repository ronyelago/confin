using AutoMapper;
using confin.api.interfaces.repositories;
using confin.api.models;
using confin.domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace confin.Controllers
{
    public class ContaController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ICadastroContaRepository _contaRepository;

        public ContaController(IMapper mapper, ICadastroContaRepository contaRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        [HttpGet("ObterTodosCadastrosContas")]
        public async Task<IActionResult> Get()
        {
            Log.Information("=> Obtendo todas as contas..");
            var compras = await _contaRepository.Get();

            return Ok(compras);
        }

        [HttpPost("NovoCadastroConta")]
        public async Task<IActionResult> Post([FromBody] NovoCadastroContaModel contaModel)
        {
            await _contaRepository.Save(_mapper.Map<CadastroConta>(contaModel));

            return Created("", contaModel);
        }
    }
}