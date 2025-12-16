using CiaAerea.Contexts;
using CiaAerea.Entities;
using CiaAerea.Validator.Manutencao;
using CiaAerea.ViewModels.Manutencao;
using FluentValidation;

namespace CiaAerea.Services;

public class ManutencaoService
{
    private readonly CiaAereaContext _context;
    private readonly AdicionarManutencaoValidator _adicionarManutencaoValidator;
    
    public ManutencaoService(CiaAereaContext context, AdicionarManutencaoValidator adicionarManutencaoValidator)
    {
        _context = context;
        _adicionarManutencaoValidator = adicionarManutencaoValidator;
    }

    public ListaManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        _adicionarManutencaoValidator.ValidateAndThrow(dados);
        
        var manutencao = new Manutencao(dados.DataHora, dados.Tipo, dados.AeronaveId, dados.Observacoes);
        
        _context.Add(manutencao);
        _context.SaveChanges();
        
        return new ListaManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Observacoes, manutencao.Tipo, manutencao.AeronaveId)!;
    }
}