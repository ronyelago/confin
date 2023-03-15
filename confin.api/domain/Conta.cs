namespace confin.domain
{
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Int16 Variabilidade { get; set; }
        public string Observacoes { get; set; }
        public int? Status { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
