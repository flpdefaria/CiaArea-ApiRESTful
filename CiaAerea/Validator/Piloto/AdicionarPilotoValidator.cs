using CiaAerea.Contexts;
using CiaAerea.ViewModels.Piloto;
using FluentValidation;

namespace CiaAerea.Validator.Piloto;

public class AdicionarPilotoValidator: AbstractValidator<AdicionarPilotoViewModel>
{
    private readonly CiaAereaContext _context;
    
    public AdicionarPilotoValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O campo Nome é obrigatório")
            .MaximumLength(50).WithMessage("O campo Nome deve ter no máximo 50 caracteres");
        
        RuleFor(p => p.Matricula)
            .NotEmpty().WithMessage("O campo Matricula é obrigatório")
            .MaximumLength(10).WithMessage("O campo Matricula deve ter no máximo 10 caracteres")
            .Must(matricula => !_context.Pilotos.Any(p => p.Matricula == matricula)).WithMessage("Já existe um piloto com essa matrícula");
    }
}