using System.Data;
using CiaAerea.Contexts;
using CiaAerea.ViewModels.Manutencao;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Validator.Manutencao;

public class AdicionarManutencaoValidator: AbstractValidator<AdicionarManutencaoViewModel>
{
    private readonly CiaAereaContext _context;

    public AdicionarManutencaoValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(m => m.DataHora)
            .NotEmpty().WithMessage("A data e hora da manutenção devem ser informadas");
        
        RuleFor(m => m.Tipo)
            .NotNull().WithMessage("O tipo da manutenção deve ser informado");

        RuleFor(m => m).Custom((manutencao, ValidationContext) =>
        {
            var aeronave = _context.Aeronaves.Include(a => a.Voos)
                .FirstOrDefault(a => a.Id == manutencao.AeronaveId);

            if (aeronave == null)
            {
                ValidationContext.AddFailure("Id de aeronave inválido.");
            }
            else
            {
                var emVoo = aeronave.Voos.Any(v => v.DataHoraPartida <= manutencao.DataHora && v.DataHoraChegada >= manutencao.DataHora);
                
                if (emVoo)
                {
                    ValidationContext.AddFailure("A aeronave está em voo nesse horário.");
                }     
            }

        });
    }
}