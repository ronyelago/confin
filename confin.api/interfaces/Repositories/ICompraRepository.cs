using confin.domain;

namespace confin.api.interfaces.repositories
{
    public interface ICompraRepository
    {
        public Task<IEnumerable<Compra>> Get();
        public Task Save(Compra compra);
    }
}
