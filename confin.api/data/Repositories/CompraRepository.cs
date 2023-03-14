using Dapper;
using confin.domain;
using confin.interfaces.Repositories;
using System.Data;

namespace confin.data.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private DbSession _session;

        public CompraRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Compra>> Get()
        {
            const string query = @"SELECT id, descricao, valor, formaPagamento, parcelada, dataCompra FROM compra";

            var result = await _session.Connection.QueryAsync<Compra>(query, null, _session.Transaction);

            return result;
        }

        public async Task Save(Compra compra)
        {
            string query = $@"INSERT INTO compra(
                                  descricao, valor, formaPagamento, parcelada, dataCompra) 
                              VALUES(
                                  @Descricao,
                                  @Valor,
                                  @FormaPagamento,
                                  @Parcelada,
                                  NOW())";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Descricao", compra.Descricao, DbType.String);
            parameters.Add("Valor", compra.Valor, DbType.Decimal);
            parameters.Add("FormaPagamento", compra.FormaPagamento, DbType.Int16);
            parameters.Add("Parcelada", compra.Parcelada, DbType.Boolean);

            await _session.Connection.ExecuteAsync(query, parameters);
        }
    }
}
