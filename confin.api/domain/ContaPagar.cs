namespace confin.domain
{
    public class ContaPagar
    {
        public int Id { get; set; }
        public int CadastroContaId { get; set; }
        public Conta CadastroConta { get; set; }
        public decimal Valor { get; set; }
        //TODO - incluir na tabela este novo campo
        public DateTime DataPagamento { get; set; }        
        public DateTime DataVencimento { get; set; }
        public StatusConta Status { get; set; }
    }

    public enum StatusConta
    {
        Pendente = 1,
        Paga = 2,
        Atrasada = 3,
        PagaAtrasada = 4
    }
}