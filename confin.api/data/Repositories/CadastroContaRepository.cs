using System.Data;
using confin.api.interfaces.repositories;
using confin.domain;
using Dapper;

namespace confin.data.Repositories
{
    public class CadastroContaRepository : ICadastroContaRepository
    {
        private readonly DbSession dbSession;

        public CadastroContaRepository(DbSession dbSession)
        {
            this.dbSession = dbSession;
        }

        public async Task<IEnumerable<Conta>> Get()
        {
            const string query = @"SELECT id
                                          ,descricao
                                          ,variabilidade
                                          ,observacoes
                                          ,diavencimento
                                          ,ativa
                                          FROM Conta";

            var result = await dbSession.Connection.QueryAsync<Conta>(query, null, dbSession.Transaction);

            return result;
        }

        public async Task Save(Conta cadastroConta)
        {
            string query = $@"INSERT INTO Conta(
                                descricao
                                ,variabilidade
                                ,observacoes
                                ,diavencimento
                                ,dataCadastro
                                ,ativa) 
                            VALUES(
                                @Descricao,
                                @Variabilidade,
                                @Observacoes,
                                @DiaVencimento
                                ,@DataCadastro
                                ,@Ativa)";

            DynamicParameters parameters = new();
            parameters.Add("Descricao", cadastroConta.Descricao, DbType.String);
            parameters.Add("Variabilidade", cadastroConta.Variabilidade, DbType.Int16);
            parameters.Add("Observacoes", cadastroConta.Observacoes, DbType.String);
            parameters.Add("DiaVencimento", cadastroConta.DiaVencimento, DbType.DateTime);
            parameters.Add("DataCadastro", cadastroConta.DataCadastro, DbType.DateTime);
            parameters.Add("Ativa", cadastroConta.Ativa, DbType.Boolean);

            await dbSession.Connection.ExecuteAsync(query, parameters);
        }
    }
}