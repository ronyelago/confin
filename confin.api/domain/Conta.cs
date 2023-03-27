namespace confin.domain
{
    public class Conta
    {
        public int Id { get; set; }
        public CadastroConta CadastroConta { get; set; }
        public decimal Valor { get; set; }
        public StatusConta Status { get; set; }
        public DateTime Vencimento { get; set; }
    }

    public enum StatusConta
    {
        Pendente = 0,
        Paga = 1,
        Atrasada = 2
    }
}