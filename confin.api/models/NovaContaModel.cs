using Confin.Domain.Entities;

namespace confin.api.models;

public class NovaContaModel
{
    public string? Descricao { get; set; }
    public Variabilidade Variabilidade { get; set; }
    public bool Ativa { get; set; }
    public string? Observacoes { get; set; }
    public int DiaVencimento { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataExpiracao { get; set; }
}