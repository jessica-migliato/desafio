using System;
using System.Collections.Generic;

namespace MyApi.Application.DTOs
{
    public class CriarTituloDto
    {
        public string NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal PercentualMulta { get; set; }
        public List<CriarParcelaDto> Parcelas { get; set; } = new();
    }

    public class CriarParcelaDto
    {
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
    }
}
