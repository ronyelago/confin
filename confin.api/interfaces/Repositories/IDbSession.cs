using System.Collections.Generic;
using System.Threading.Tasks;

namespace confin.api.interfaces.repositories;
public interface IDbSession
{
    Task<T> GetAsync<T> (string command, object parms);
    Task<List<T>> GetAll<T> (string command, object parms);
    Task<T> Insert<T> (string command, object parmms);
    Task<T> Update<T> (string command, object parms);
}