using CiaAerea.Contexts;
using CiaAerea.ViewModels.Aeronave;
using FluentValidation;

namespace CiaAerea.Validator.Aeronave;

public class AtualizarAeronaveValidator:AbstractValidator<AtualizarAeronaveViewModel>
{
    private readonly CiaAereaContext _context;
    
    public AtualizarAeronaveValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(a => a.Fabricante)
            .NotEmpty().WithMessage("O campo Fabricante é obrigatório")
            .MaximumLength(50).WithMessage("O campo Fabricante deve ter no máximo 50 caracteres");
        
        RuleFor(a => a.Modelo)
            .NotEmpty().WithMessage("O campo Modelo é obrigatório")
            .MaximumLength(50).WithMessage("O campo Modelo deve ter no máximo 50 caracteres");
        
        RuleFor(a => a.Codigo)
            .NotEmpty().WithMessage("O campo Codigo é obrigatório")
            .MaximumLength(10).WithMessage("O campo Codigo deve ter no máximo 10 caracteres")
            .Must(codigo => !_context.Aeronaves.Any(a => a.Codigo == codigo)).WithMessage("Já existe uma aeronave com esse código");
        
        RuleFor(a => a)
            .Must(aeronave => _context.Aeronaves.Count(a => a.Codigo == aeronave.Codigo && a.Id != aeronave.Id) == 0).WithMessage("Já existe uma aeronave com esse código");

    }
}