namespace confin.domain
{
    public class Conta
    {   
        public Conta()
        {
            ContasPagar = new List<Conta>();
        }

        public int Id { get; set; }
        public string? Descricao { get; set; }
        public Variabilidade Variabilidade { get; set; }
        public bool Ativa { get; set; }
        public Ciclo Ciclo { get; set; }
        public string? Observacoes { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataExpiracao { get; set; }
        public List<ContaPagar> ContasPagar { get; set; }
    }

    public enum Ciclo
    {
        Mensal = 1,
        Anual = 2
    }

    public enum Variabilidade
    {
        Invariavel = 0,
        Baixa = 1,
        Media = 2,
        Alta = 3,
        Altissima = 4
    }
}
