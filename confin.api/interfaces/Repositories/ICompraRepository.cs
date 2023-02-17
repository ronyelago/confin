using confin.domain;

namespace confin.interfaces.Repositories
{
    public interface ICompraRepository
    {
        public Task<IEnumerable<Compra>> Get();
        public Task Save(Compra compra);
    }
}
