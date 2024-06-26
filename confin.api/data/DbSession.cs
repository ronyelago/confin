using confin.api.interfaces.repositories;
using Dapper;
using Npgsql;
using System.Data;

namespace confin.data;
public sealed class DbSession : IDbSession, IDisposable
{
    private Guid _id;
    private readonly IConfiguration _configuration;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    public DbSession(IConfiguration configuration)
    {
        _id = Guid.NewGuid();
        _configuration = configuration;
        Connection = new NpgsqlConnection(_configuration.GetConnectionString("Finacon"));
    }

    public async Task<T> GetAsync<T>(string command, object parms)
    {
        return (await Connection.QueryAsync<T>(command, parms)
                    .ConfigureAwait(false))
                    .FirstOrDefault();
    }

    public async Task<List<T>> GetAll<T>(string command, object parms)
    {
        return (await Connection.QueryAsync<T>(command, parms)).ToList();
    }

    public async Task<T> Insert<T>(string command, object parms)
    {
        T result;
        result = Connection.Query<T>(command, parms, transaction: null, commandTimeout: 60, commandType: CommandType.Text).FirstOrDefault();

        return result;
    }

    public async Task<T> Update<T>(string command, object parms)
    {
        T result;
        result =  Connection.Query<T>(command, parms, transaction: null, commandTimeout:60,commandType :CommandType.Text).FirstOrDefault();
        return result;
    }

    public void Dispose() => Connection?.Dispose();
}