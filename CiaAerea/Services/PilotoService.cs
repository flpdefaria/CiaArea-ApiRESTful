using CiaAerea.Contexts;
using CiaAerea.Entities;
using CiaAerea.Validator.Piloto;
using CiaAerea.ViewModels.Piloto;
using FluentValidation;

namespace CiaAerea.Services;

public class PilotoService
{
    private readonly CiaAereaContext _context;

    private readonly AdicionarPilotoValidator _adicionarPilotoValidator;
    private readonly AtualizarPilotoValidator _atualizarPilotoValidator;

    public PilotoService(CiaAereaContext context, AdicionarPilotoValidator adicionarPilotoValidator, AtualizarPilotoValidator atualizarPilotoValidator)
    {
        _context = context;
        _adicionarPilotoValidator = adicionarPilotoValidator;
        _atualizarPilotoValidator = atualizarPilotoValidator;
    }

    public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        _adicionarPilotoValidator.ValidateAndThrow(dados);
        
        var piloto = new Piloto(dados.Nome, dados.Matricula);
        
        _context.Add(piloto);
        _context.SaveChanges();
        
        return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
    }

    public IEnumerable<ListarPilotoViewModel> ListarPilotos()
    {
        return _context.Pilotos.Select(p => new ListarPilotoViewModel
        (
            p.Id, 
            p.Nome
            )
        );
    }

    public DetalhesPilotoViewModel? ListarPilotoId(int id)
    {
        var piloto = _context.Pilotos.Find(id);
        
        if (piloto != null)
        {
            return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
        }
        
        return null;
    }

    public DetalhesPilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados)
    {
        _atualizarPilotoValidator.ValidateAndThrow(dados);
        
        var piloto = _context.Pilotos.Find(dados.Id);
        
        if (piloto != null)
        {
            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;
            
            _context.Update(piloto);
            _context.SaveChanges();
            
            return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
        }
        
        return null;
    }
}