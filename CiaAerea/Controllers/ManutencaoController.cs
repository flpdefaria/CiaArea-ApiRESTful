using CiaAerea.Services;
using CiaAerea.ViewModels.Manutencao;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers;

[Route("api/manutencoes")]
[ApiController]

public class ManutencaoController : ControllerBase
{
    private readonly ManutencaoService _manutencaoService;

    public ManutencaoController(ManutencaoService manutencaoService)
    {
        _manutencaoService = manutencaoService;
    }

    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }
}