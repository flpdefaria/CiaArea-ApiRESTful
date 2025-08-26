using CiaAerea.Contexts;
using CiaAerea.Services;
using CiaAerea.ViewModels.Piloto;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers;

[Route("api/pilotos")]
[ApiController]
public class PilotoController:ControllerBase
{
    private readonly PilotoService _pilotoService;

    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }

    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);
    }
    
    [HttpGet]
    public IActionResult ListarPilotos()
    {
        return Ok(_pilotoService.ListarPilotos());
    }

    [HttpGet("{id}")]
    public IActionResult ListarPilotoId(int id)
    {
        var piloto = _pilotoService.ListarPilotoId(id);
        
        if (piloto != null)
        {
            return Ok(piloto);
        }
        
        return NotFound();
    }
    
    [HttpPut("{id}")]
    public IActionResult AtualizarPiloto(int id, AtualizarPilotoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL não confere com o id informado no corpo da requisição.");
        }   
        
        var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);
    }
    
}