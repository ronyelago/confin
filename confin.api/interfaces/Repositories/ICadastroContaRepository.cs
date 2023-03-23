using confin.domain;

namespace confin.api.interfaces.repositories
{
    public interface ICadastroContaRepository
    {
        public Task<IEnumerable<CadastroConta>> Get();
        public Task Save(CadastroConta conta);
    }
}