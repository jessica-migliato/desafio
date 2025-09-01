using System;
using System.Collections.Generic;
using System.Linq;
using MyApi.Domain.Entities;
using MyApi.Application.DTOs;

namespace MyApi.Application.Services
{
    public class TituloService
    {
        public int CalcularDiasAtraso(DateTime dataVencimento)
        {
            int diasAtraso = (DateTime.Today - dataVencimento).Days;
            return diasAtraso > 0 ? diasAtraso : 0;
        }

        public decimal CalcularMulta(Titulo titulo)
        {
            decimal valorTotal = titulo.Parcelas.Sum(p => p.Valor);
            return valorTotal * (titulo.PercentualMulta / 100m);
        }

        public decimal CalcularJuros(decimal percentualJuros, int diasAtraso, decimal valorParcela)
        {
            return (percentualJuros / 100m / 30) * diasAtraso * valorParcela;
        }

        public TituloListagemDto MapToListagemDto(Titulo titulo)
        {
            var dto = new TituloListagemDto
            {
                Id = titulo.Id,
                NumeroTitulo = titulo.NumeroTitulo,
                NomeDevedor = titulo.NomeDevedor,
                CpfDevedor = titulo.CpfDevedor,
                ValorTotal = titulo.Parcelas.Sum(p => p.Valor),
                Parcelas = new List<ParcelaListagemDto>()
            };

            decimal valorAtualizado = 0;
            foreach (var parcela in titulo.Parcelas)
            {
                int diasAtraso = CalcularDiasAtraso(parcela.DataVencimento);
                decimal multa = diasAtraso > 0 ? parcela.Valor * (titulo.PercentualMulta / 100m) : 0;
                decimal juros = diasAtraso > 0 ? CalcularJuros(titulo.PercentualJuros, diasAtraso, parcela.Valor) : 0;
                decimal valorParcelaAtualizado = parcela.Valor + multa + juros;
                valorAtualizado += valorParcelaAtualizado;

                dto.Parcelas.Add(new ParcelaListagemDto
                {
                    Id = parcela.Id,
                    NumeroParcela = parcela.NumeroParcela,
                    DataVencimento = parcela.DataVencimento,
                    Valor = parcela.Valor,
                    DiasAtraso = diasAtraso,
                    Multa = multa,
                    Juros = juros,
                    ValorAtualizado = valorParcelaAtualizado
                });
            }
            dto.ValorAtualizado = valorAtualizado;
            return dto;
        }
    }
}
