namespace confin.domain
{
    public class ContaPagar
    {
        public int Id { get; set; }
        public Conta Conta { get; set; }
        public decimal Valor { get; set; }
        public StatusConta Status { get; set; }
    }

    public enum StatusConta
    {
        Pendente = 0,
        Paga = 1,
        Atrasada = 2

    }
}