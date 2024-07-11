using System.Data;
using confin.api.interfaces.repositories;
using Dapper;
using Confin.Domain.Entities;

namespace confin.data.Repositories;
public class CompraRepository : ICompraRepository
{
    private DbSession _session;

    public CompraRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<IReadOnlyList<Compra>> GetAllAsync()
    {
        const string query = @"SELECT id, descricao, valor, formaPagamento, parcelada, dataCompra FROM compra";

        var result = await _session.Connection.QueryAsync<Compra>(query, null, _session.Transaction);

        return result.ToList();
    }

    public async Task<string> AddAsync(Compra compra)
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

        var result = await _session.Connection.ExecuteAsync(query, parameters);

        return result.ToString();
    }
}

