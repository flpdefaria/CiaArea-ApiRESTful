using CiaAerea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Validator.Aeronave;

public class ExcluirAeronaveValidator:AbstractValidator<int>
{
    private readonly CiaAereaContext _context;

    public ExcluirAeronaveValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(id => _context.Aeronaves.Include(a => a.Voos).Include(a => a.Manutencoes).FirstOrDefault(a => a.Id == id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Aeronave não encontrada")
            .Must(aeronave => aeronave!.Voos.Count == 0).WithMessage("Aeronave possui voos")
            .Must(aeronave => aeronave!.Manutencoes.Count == 0).WithMessage("Aeronave possui manutenções");
    }
}