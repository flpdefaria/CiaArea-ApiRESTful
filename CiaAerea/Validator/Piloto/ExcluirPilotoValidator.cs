using CiaAerea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Validator.Piloto;

public class ExcluirPilotoValidator :AbstractValidator<int>
{
    private readonly CiaAereaContext _context;
    
    public ExcluirPilotoValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(id => _context.Pilotos.Include(p => p.Voos).FirstOrDefault(p => p.Id == id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Piloto não encontrado")
            .Must(piloto => piloto!.Voos.Count == 0).WithMessage("Piloto possui voos");
    }
}