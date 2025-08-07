using CiaAerea.Services;
using CiaAerea.ViewModels.Aeronave;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers;

// [Route("api/[controller]")]
[Route("api/aeronaves")]
[ApiController]

public class AeronaveController : ControllerBase
{
    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }
    
    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        return Ok(aeronave);
    }
    
    [HttpGet]
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }
    
    [HttpGet("{id}")] 
    public IActionResult ListarAeronaveId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronaveId(id);
        
        if (aeronave != null)
        {
            return Ok(aeronave);
        }
        
        return NotFound();
    }
    
    [HttpPut("{id}")] 
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL não confere com o id informado no corpo da requisição.");
        }   
        
        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);

    }
    
}