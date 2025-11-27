using CiaAerea.Services;
using CiaAerea.ViewModels.Voo;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers;

    [Route("api/voos")]
    [ApiController]

    public class VooController: ControllerBase
    {
        private readonly VooService _vooService;

        public VooController(VooService vooService)
        {
            _vooService = vooService;
        }

        [HttpPost]
        public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
        {
            var voo = _vooService.AdicionarVoo(dados);
            return CreatedAtAction(nameof(ListarVooPeloId), new { voo.Id }, voo);
        }

        [HttpGet]
        public IActionResult ListarVoos(string? origem, string? destino, DateTime? partida, DateTime? chegada)
        {
            return Ok(_vooService.ListarVoos(origem, destino, partida, chegada));
        }
        
        [HttpGet("{id}")]
        public IActionResult ListarVooPeloId(int id)
        {
            var voo = _vooService.ListarVooPeloId(id);
            
            if (voo != null)
            {
                return Ok(voo);
            }
            
            return NotFound();
        }
    }
    