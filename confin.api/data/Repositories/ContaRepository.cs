using System.Data;
using confin.api.interfaces.repositories;
using confin.domain;
using Dapper;

namespace confin.data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly DbSession dbSession;

        public ContaRepository(DbSession dbSession)
        {
            this.dbSession = dbSession;
        }

        public async Task<IReadOnlyList<Conta>> GetAllAsync()
        {
            const string query = @"SELECT id
                                          ,descricao
                                          ,variabilidade
                                          ,valorMedio
                                          ,observacoes
                                          ,diavencimento
                                          ,ativa
                                          FROM Conta";

            var contas = await dbSession.Connection.QueryAsync<Conta>(query, null, dbSession.Transaction);

            return contas.ToList();
        }

        public async Task<string> AddAsync(Conta conta)
        {
            string query = $@"INSERT INTO Conta(
                                descricao
                                ,variabilidade
                                ,valorMedio
                                ,observacoes
                                ,diavencimento
                                ,dataCadastro
                                ,ativa) 
                            VALUES(
                                @Descricao,
                                @Variabilidade,
                                @ValorMedio,
                                @Observacoes,
                                @DiaVencimento
                                ,@DataCadastro
                                ,@Ativa)";

            DynamicParameters parameters = new();
            parameters.Add("Descricao", conta.Descricao, DbType.String);
            parameters.Add("Variabilidade", conta.Variabilidade, DbType.Int16);
            parameters.Add("ValorMedio", conta.ValorMedio, DbType.Decimal);
            parameters.Add("Observacoes", conta.Observacoes, DbType.String);
            parameters.Add("DiaVencimento", conta.DiaVencimento, DbType.DateTime);
            parameters.Add("DataCadastro", conta.DataCadastro, DbType.DateTime);
            parameters.Add("Ativa", conta.Ativa, DbType.Boolean);

            var result = await dbSession.Connection.ExecuteAsync(query, parameters);

            return result.ToString();
        }
    }
}