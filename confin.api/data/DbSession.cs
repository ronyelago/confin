using Npgsql;
using System.Data;

namespace confin.data
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            Connection = new NpgsqlConnection(configuration.GetConnectionString("Finacon"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
