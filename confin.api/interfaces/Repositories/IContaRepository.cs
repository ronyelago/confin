using confin.domain;

namespace confin.api.interfaces.repositories
{
    public interface IContaRepository
    {
        public Task<IEnumerable<Conta>> Get();
        public Task Save(Conta conta);
    }
}