using CiaAerea.Contexts;
using CiaAerea.Entities;
using CiaAerea.Validator.Voo;
using CiaAerea.ViewModels.Voo;
using FluentValidation;

namespace CiaAerea.Services;

public class VooService
{
    private readonly CiaAereaContext _context;
    private readonly AdicionarVooValidator _adicionarVooValidator;

    public VooService(CiaAereaContext context, AdicionarVooValidator adicionarVooValidator)
    {
        _context = context;
        _adicionarVooValidator = adicionarVooValidator;
    }

    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
    {
        _adicionarVooValidator.ValidateAndThrow(dados);
        
        var voo = new Voo(
            dados.Origem, 
            dados.Destino, 
            dados.DataHoraPartida, 
            dados.DataHoraChegada, 
            dados.AeronaveId, 
            dados.PilotoId
            );
        
        _context.Add(voo);
        _context.SaveChanges();
        
        return new DetalhesVooViewModel(
            voo.Id, 
            voo.Origem, 
            voo.Destino, 
            voo.DataHoraPartida, 
            voo.DataHoraChegada, 
            voo.AeronaveId, 
            voo.PilotoId
            );
    }
    
    public IEnumerable<ListarVooViewModel> ListarVoos(string? origem, string? destino, DateTime? partida, DateTime? chegada)
    {
        var filtroOrigem = (Voo voo) => string.IsNullOrEmpty(origem) || voo.Origem == origem;
        var filtroDestino = (Voo voo) => string.IsNullOrEmpty(destino) || voo.Destino == destino;
        var filtroPartida = (Voo voo) => !partida.HasValue || voo.DataHoraPartida >= partida;
        var filtroChegada = (Voo voo) => !chegada.HasValue || voo.DataHoraChegada <= chegada;
        
        return _context.Voos
            .Where(filtroOrigem)
            .Where(filtroDestino)
            .Where(filtroPartida)
            .Where(filtroChegada)
            .Select(v => new ListarVooViewModel(
            v.Id, 
            v.Origem, 
            v.Destino, 
            v.DataHoraPartida, 
            v.DataHoraChegada
        ));
    }
}