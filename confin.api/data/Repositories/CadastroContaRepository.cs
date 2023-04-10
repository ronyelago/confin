using System.Data;
using confin.api.interfaces.repositories;
using confin.domain;
using Dapper;

namespace confin.data.Repositories
{
    public class CadastroContaRepository : ICadastroContaRepository
    {
        private readonly DbSession _session;

        public CadastroContaRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Conta>> Get()
        {
            const string query = @"SELECT id
                                          ,descricao
                                          ,variabilidade
                                          ,observacoes
                                          ,vencimento
                                          ,ativa
                                          FROM CadastroConta";

            var result = await _session.Connection.QueryAsync<Conta>(query, null, _session.Transaction);

            return result;
        }

        public async Task Save(Conta cadastroConta)
        {
            string query = $@"INSERT INTO CadastroConta(
                                descricao
                                ,variabilidade
                                ,observacoes
                                ,vencimento
                                ,dataCadastro
                                ,ativa) 
                            VALUES(
                                @Descricao,
                                @Variabilidade,
                                @Observacoes,
                                @Vencimento
                                ,@DataCadastro
                                ,@Ativa)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Descricao", cadastroConta.Descricao, DbType.String);
            parameters.Add("Variabilidade", cadastroConta.Variabilidade, DbType.Int16);
            parameters.Add("Observacoes", cadastroConta.Observacoes, DbType.String);
            parameters.Add("Vencimento", cadastroConta.Vencimento, DbType.DateTime);
            parameters.Add("DataCadastro", cadastroConta.DataCadastro, DbType.DateTime);
            parameters.Add("Ativa", cadastroConta.Ativa, DbType.Boolean);

            await _session.Connection.ExecuteAsync(query, parameters);
        }
    }
}