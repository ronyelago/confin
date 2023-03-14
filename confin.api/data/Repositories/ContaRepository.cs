using System.Data;
using confin.api.interfaces.repositories;
using confin.domain;
using Dapper;

namespace confin.data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly DbSession _session;

        public ContaRepository(DbSession session)
        {
            _session = session;
        }

        public Task<IEnumerable<Conta>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task Save(Conta conta)
        {
                        string query = $@"INSERT INTO conta(
                                            descricao, valor, variabilidade, vencimento) 
                                        VALUES(
                                            @Descricao,
                                            @Valor,
                                            @Variabilidade,
                                            @Vencimento)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Descricao", conta.Descricao, DbType.String);
            parameters.Add("Valor", conta.Valor, DbType.Decimal);
            parameters.Add("Variabilidade", conta.Variabilidade, DbType.Int16);
            parameters.Add("Vencimento", conta.Vencimento, DbType.DateTime);

            await _session.Connection.ExecuteAsync(query, parameters);
        }
    }
}