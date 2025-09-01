using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Domain;
using MyApi.Domain.Entities;
using MyApi.Application.DTOs;
using MyApi.Application.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitulosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TituloService _service;

        public TitulosController(AppDbContext context)
        {
            _context = context;
            _service = new TituloService();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarTituloDto dto)
        {
            var titulo = new Titulo
            {
                NumeroTitulo = dto.NumeroTitulo,
                NomeDevedor = dto.NomeDevedor,
                CpfDevedor = dto.CpfDevedor,
                PercentualJuros = dto.PercentualJuros,
                PercentualMulta = dto.PercentualMulta,
                Parcelas = dto.Parcelas.Select(p => new Parcela
                {
                    NumeroParcela = p.NumeroParcela,
                    DataVencimento = DateTime.SpecifyKind(p.DataVencimento, DateTimeKind.Utc),
                    Valor = p.Valor
                }).ToList()
            };
            _context.Titulos.Add(titulo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = titulo.Id }, _service.MapToListagemDto(titulo));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TituloListagemDto>>> Get()
        {
            var titulos = await _context.Titulos.Include(t => t.Parcelas).ToListAsync();
            var dtos = titulos.Select(t => _service.MapToListagemDto(t)).ToList();
            return Ok(dtos);
        }
    }
}
