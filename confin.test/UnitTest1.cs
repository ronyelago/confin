using Dapper;
using System.Data;
using confin.domain;
using confin.data.Repositories;
using confin.data;
using Moq;
using confin.api.interfaces.repositories;

namespace confin.test;

public class CadastroContaRepositoryTests
{
    private readonly Mock<IDbService> _mockService;
    private readonly CadastroContaRepository _repository;

    public CadastroContaRepositoryTests()
    {
        _mockService = new Mock<IDbService>();
        _repository = new CadastroContaRepository(_mockService.Object);
    }

    [Fact]
    public async Task Get_Should_Return_Conta_List()
    {
        // Arrange
        const string query = @"SELECT id, descricao, variabilidade, observacoes, diavencimento, ativa FROM Conta";
        var mockResult = new List<Conta>() { /* adicione os objetos Conta fictícios aqui */ };
        _mockSession.SetupGet(x => x.Connection).Returns(Mock.Of<IDbConnection>());
        _mockSession.SetupGet(x => x.Transaction).Returns(Mock.Of<IDbTransaction>());
        _mockSession.SetupGet(x => x.Connection).Returns(Mock.Of<IDbConnection>());
        _mockSession.Setup(x => x.Connection.QueryAsync<Conta>(query, null, _mockSession.Object.Transaction, null, null)).ReturnsAsync(mockResult);


        // Act
        var result = await _repository.Get();

        // Assert
        Assert.Equal(mockResult, result);
    }
}