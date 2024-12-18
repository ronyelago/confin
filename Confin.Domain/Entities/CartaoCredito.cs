namespace Confin.Domain.Entities;
public class CartaoCredito
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal FaturaAtual { get; set; }
    public decimal Limite { get; set; }
    public decimal DividaTotal { get; set; }
    public int ContaId { get; set; }
    public Conta Conta { get; set; }
}