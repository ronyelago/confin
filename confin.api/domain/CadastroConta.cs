namespace confin.domain
{
    public class CadastroConta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Int16 Variabilidade { get; set; }
        public string Observacoes { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativa { get; set; }
        public Ciclo Ciclo { get; set; }
        public List<Conta> ContasPagar { get; set; }
    }

    public enum Ciclo
    {
        Mensal = 0
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
