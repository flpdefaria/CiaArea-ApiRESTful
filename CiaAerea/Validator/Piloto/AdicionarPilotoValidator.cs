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
            .MaximumLength(100).WithMessage("O campo Nome deve ter no máximo 100 caracteres");
        
        RuleFor(p => p.Matricula)
            .NotEmpty().WithMessage("O campo Matrícula é obrigatório")
            .MaximumLength(10).WithMessage("O campo Matrícula deve ter no máximo 10 caracteres")
            .Must(matricula => _context.Pilotos.Count(p => p.Matricula == matricula) == 0).WithMessage("Já existe um piloto com essa matrícula");
    }
}