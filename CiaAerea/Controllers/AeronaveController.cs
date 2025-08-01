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
}