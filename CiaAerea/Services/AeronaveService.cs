using CiaAerea.Contexts;
using CiaAerea.Entities;
using CiaAerea.ViewModels.Aeronave;

namespace CiaAerea.Services;

public class AeronaveService
{
    private readonly CiaAereaContext _context;

    public AeronaveService(CiaAereaContext context)
    {
        _context = context;
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);
        
        _context.Aeronaves.Add(aeronave);
        _context.SaveChanges();
        
        return new DetalhesAeronaveViewModel
        (
            aeronave.Id, 
            aeronave.Fabricante, 
            aeronave.Modelo, 
            aeronave.Codigo
        );
    }

    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves()
    {
        return _context.Aeronaves.Select(a => new ListarAeronaveViewModel
            (
            a.Id, 
            a.Modelo, 
            a.Codigo)
        );
    }

}