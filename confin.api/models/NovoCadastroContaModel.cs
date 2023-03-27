using confin.domain;

namespace confin.api.models
{
    public class NovoCadastroContaModel
    {
        public string? Descricao { get; set; }
        public Variabilidade Variabilidade { get; set; }
        public bool Ativa { get; set; }
        public Ciclo Ciclo { get; set; }
        public string? Observacoes { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}