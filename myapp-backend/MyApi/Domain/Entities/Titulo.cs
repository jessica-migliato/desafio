using System;
using System.Collections.Generic;

namespace MyApi.Domain.Entities
{
    public class Titulo
    {
        public int Id { get; set; }
        public string NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public string CpfDevedor { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal PercentualMulta { get; set; }
        public List<Parcela> Parcelas { get; set; } = new();
    }
}
