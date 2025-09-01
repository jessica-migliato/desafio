using System;
using System.Collections.Generic;

namespace MyApi.Application.DTOs
{
    public class TituloListagemDto
    {
        public int Id { get; set; }
        public string NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorAtualizado { get; set; }
        public List<ParcelaListagemDto> Parcelas { get; set; } = new();
    }

    public class ParcelaListagemDto
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int DiasAtraso { get; set; }
        public decimal Multa { get; set; }
        public decimal Juros { get; set; }
        public decimal ValorAtualizado { get; set; }
    }
}
