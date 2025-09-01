using System;
using System.Collections.Generic;
using MyApi.Domain.Entities;
using MyApi.Application.Services;
using Xunit;

namespace MyApi.Application.Tests.Services
{
    public class TituloServiceTests
    {
        [Fact]
        public void CalcularDiasAtraso_DeveRetornarDiasCorretos()
        {
            var service = new TituloService();
            var vencimento = DateTime.Today.AddDays(-5);
            int dias = service.CalcularDiasAtraso(vencimento);
            Assert.Equal(5, dias);
        }

        [Fact]
        public void CalcularMulta_DeveRetornarMultaCorreta()
        {
            var titulo = new Titulo
            {
                PercentualMulta = 2,
                Parcelas = new List<Parcela> { new Parcela { Valor = 100 }, new Parcela { Valor = 50 } }
            };
            var service = new TituloService();
            decimal multa = service.CalcularMulta(titulo);
            Assert.Equal(3, multa);
        }

        [Fact]
        public void CalcularJuros_DeveRetornarJurosCorretos()
        {
            var service = new TituloService();
            decimal juros = service.CalcularJuros(1, 30, 100);
            Assert.Equal(1, juros, 2);
        }
    }
}
