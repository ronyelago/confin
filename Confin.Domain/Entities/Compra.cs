using System;
using System.ComponentModel;

namespace Confin.Domain.Entities;
public record Compra
{
    public int Id { get; set; }
    public Conta Conta { get; set; }
    public int? ContaId { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public bool Parcelada { get; set; }
    public DateTime DataCompra { get; set; }
}

public enum FormaPagamento
{
    [Description("Crédito a Vista")]
    Credito = 1,

    [Description("Débito")]
    Debito = 2,

    [Description("Pix")]
    Pix = 3,

    [Description("Crédito Parcelado")]
    CreditoParcelado = 4,

    [Description("À Vista")]
    Dinheiro = 5
}