using confin.domain;

namespace confin.api.interfaces.repositories
{
    public interface ICadastroContaRepository
    {
        public Task<IEnumerable<Conta>> Get();
        public Task Save(Conta conta);
    }
}