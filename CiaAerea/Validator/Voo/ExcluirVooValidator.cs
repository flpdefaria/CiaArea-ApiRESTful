using CiaAerea.Contexts;
using FluentValidation;

namespace CiaAerea.Validator.Voo;

    public class ExcluirVooValidator: AbstractValidator<int> {
        
     private readonly CiaAereaContext _context;
     
     public ExcluirVooValidator(CiaAereaContext context)
     {
         _context = context;

         RuleFor(id => _context.Voos.Find(id))
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("Id do voo inválido.")
             .Must(voo => voo!.DataHoraChegada > DateTime.Now).WithMessage("Não é possível excluir um voo que já tenha partido.");

     }
}