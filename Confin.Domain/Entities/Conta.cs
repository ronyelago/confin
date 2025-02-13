﻿using System;
using System.Collections.Generic;

namespace Confin.Domain.Entities;
public class Conta
{   
    public Conta()
    {
        ContasPagar = new List<ContaPagar>();
    }

    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal ValorMedio {get; set; } = 0;
    public Variabilidade Variabilidade { get; set; }
    public bool Ativa { get; set; }
    public string Observacoes { get; set; }
    public int DiaVencimento { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataExpiracao { get; set; }
    public List<ContaPagar> ContasPagar { get; set; }
}

public enum Variabilidade
{
    Baixa = 1,
    Media = 2,
    Alta = 3,
}