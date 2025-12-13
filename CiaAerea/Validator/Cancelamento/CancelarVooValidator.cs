using System.Data;
using CiaAerea.Contexts;
using CiaAerea.ViewModels.Cancelamento;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Validator.Cancelamento;

public class CancelarVooValidator:AbstractValidator<CancelarVooViewModel>
{
    private readonly CiaAereaContext _context;
    
    public CancelarVooValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(c => c).Custom((cancelamento, ValidationContext) =>
        {
            var voo = _context.Voos.Include(v => v.Cancelamento)
                .FirstOrDefault(v => v.Id == cancelamento.VooId);

            if (voo == null)
            {
                ValidationContext.AddFailure("Id de voo inválido.");
            }
            else
            {
                if (voo.Cancelamento != null)
                {
                   ValidationContext.AddFailure("Não é possível cancelar um Voo que já foi cancelado.");
                }

                if (voo.DataHoraPartida <= DateTime.Now && voo.DataHoraChegada >= DateTime.Now)
                {
                    ValidationContext.AddFailure("Não é possível cancelar um Voo que já partiu.");
                }

                if (voo.DataHoraChegada < DateTime.Now)
                {
                    ValidationContext.AddFailure("Não é possível cancelar um Voo que já chegou.");
                }
            }
        });
    }
}