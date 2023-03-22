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

        public async Task<IEnumerable<CadastroConta>> Get()
        {
            const string query = @"SELECT id
                                          ,descricao
                                          ,variabilidade
                                          ,observacoes
                                          ,vencimento 
                                          FROM conta";

            var result = await _session.Connection.QueryAsync<CadastroConta>(query, null, _session.Transaction);

            return result;
        }

        public async Task Save(CadastroConta conta)
        {
            string query = $@"INSERT INTO conta(
                                descricao
                                ,variabilidade
                                ,observacoes
                                ,vencimento) 
                            VALUES(
                                @Descricao,
                                @Valor,
                                @Variabilidade,
                                @Observacoes,
                                @Status,
                                @Vencimento)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Descricao", conta.Descricao, DbType.String);
            parameters.Add("Variabilidade", conta.Variabilidade, DbType.Int16);
            parameters.Add("Observacoes", conta.Observacoes, DbType.String);
            parameters.Add("Vencimento", conta.Vencimento, DbType.DateTime);

            await _session.Connection.ExecuteAsync(query, parameters);
        }
    }
}