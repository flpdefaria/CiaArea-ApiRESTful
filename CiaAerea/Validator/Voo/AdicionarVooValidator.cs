using CiaAerea.Contexts;
using CiaAerea.ViewModels.Voo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Validator.Voo;

public class AdicionarVooValidator: AbstractValidator<AdicionarVooViewModel>
{
    private readonly CiaAereaContext _context;
    
    public AdicionarVooValidator(CiaAereaContext context)
    {
        _context = context;
        
        RuleFor(o => o.Origem)
            .NotEmpty().WithMessage("O campo Origem é obrigatório")
            .Length(3).WithMessage("O campo Origem deve ter no máximo 3 caracteres");
        
        RuleFor(d => d.Destino)
            .NotEmpty().WithMessage("O campo Destino é obrigatório")
            .Length(3).WithMessage("O campo Destino deve ter no máximo 3 caracteres");
        
       RuleFor(v => v)
           .Must(voo => voo.DataHoraPartida > DateTime.Now).WithMessage("A data e hora de partida deve ser maior que a data e hora atual")
           .Must(voo => voo.DataHoraChegada > voo.DataHoraPartida).WithMessage("A data e hora de chegada deve ser maior que a data e hora de partida");

       RuleFor(v => v).Custom((voo, validationContext) => {
           var piloto = _context.Pilotos
               .Include(p => p.Voos)
               .FirstOrDefault(p => p.Id == voo.PilotoId);

           if (piloto == null)
           {
               validationContext.AddFailure("PilotoId", "Piloto nao encontrado");
           }
           else
           {
               var pilotoEmVoo = piloto.Voos.Any(v => (v.DataHoraPartida <= voo.DataHoraPartida && v.DataHoraChegada >= voo.DataHoraChegada) ||
                                                                (v.DataHoraPartida >= voo.DataHoraChegada && v.DataHoraChegada <= voo.DataHoraChegada) ||
                                                                (v.DataHoraChegada >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada));
               if (pilotoEmVoo)
               {
                   validationContext.AddFailure("PilotoId", "Piloto ja possui um voo nesse periodo");
               }
           }

           var aeronave = _context.Aeronaves
               .Include(a => a.Voos)
               .Include(a => a.Manutencoes)
               .FirstOrDefault(a => a.Id == voo.AeronaveId);

           if (aeronave == null)
           {
               validationContext.AddFailure("AeronaveId", "Aeronave nao encontrada");
           }
           else
           {
               var aeronaveEmVoo = aeronave.Voos.Any(v => (v.DataHoraPartida <= voo.DataHoraPartida && v.DataHoraChegada >= voo.DataHoraChegada) ||
                                                                    (v.DataHoraPartida >= voo.DataHoraChegada && v.DataHoraChegada <= voo.DataHoraChegada) ||
                                                                    (v.DataHoraChegada >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada));
               if (aeronaveEmVoo)
               {
                   validationContext.AddFailure("Aeronave", "Esta aeronave estará em voo no horário selecionado");
               }

               var aeronaveEmManutencao = aeronave.Manutencoes.Any(m =>
                   m.DataHora >= voo.DataHoraPartida && m.DataHora >= voo.DataHoraChegada);
               
               if (aeronaveEmManutencao)
               {
                   validationContext.AddFailure( "Esta aeronave estará em manutenção no horário selecionado");
               }
           }

       });

    }
}