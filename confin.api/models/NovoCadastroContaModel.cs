namespace confin.api.models
{
    public class NovoCadastroContaModel
    {
        public string Descricao { get; set; }
        public Int16 Variabilidade { get; set; }
        public string Observacoes { get; set; }
        public DateTime Vencimento { get; set; }
        public bool Ativa { get; set; }
    }
}