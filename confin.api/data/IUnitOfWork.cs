using System;

namespace confin.data;
public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
