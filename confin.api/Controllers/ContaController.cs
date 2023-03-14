using AutoMapper;
using confin.api.interfaces.repositories;
using confin.api.models;
using confin.domain;
using Microsoft.AspNetCore.Mvc;

namespace confin.Controllers
{
    public class ContaController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IContaRepository _contaRepository;

        public ContaController(IMapper mapper, IContaRepository contaRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        [HttpPost("NovaConta")]
        public async Task<IActionResult> Post([FromBody] NovaContaModel contaModel)
        {
            await _contaRepository.Save(_mapper.Map<Conta>(contaModel));

            return Created("", contaModel);
        }
    }
}