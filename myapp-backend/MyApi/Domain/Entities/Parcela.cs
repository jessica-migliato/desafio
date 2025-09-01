using System;

namespace MyApi.Domain.Entities
{
    public class Parcela
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int TituloId { get; set; }
    }
}
