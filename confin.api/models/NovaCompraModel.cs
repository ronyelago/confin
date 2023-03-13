using confin.domain;

namespace confin.api.models
{
    public class NovaCompraModel
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Parcelada { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DateTime DataCompra { get; set; }
    }
}