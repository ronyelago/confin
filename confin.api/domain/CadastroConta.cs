namespace confin.domain
{
    public class CadastroConta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Int16 Variabilidade { get; set; }
        public string Observacoes { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativa { get; set; }
        public List<ContaPagar> ContasPagar { get; set; }
    }
}
