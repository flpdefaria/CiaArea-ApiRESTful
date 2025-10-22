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
            return Ok(voo);
        }

        [HttpGet]
        public IActionResult ListarVoos()
        {
            return Ok(_vooService.ListarVoos());
        }
    }
    