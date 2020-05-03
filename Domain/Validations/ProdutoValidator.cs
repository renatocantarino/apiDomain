using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class ProdutoValidator  : AbstractValidator<Produto>
    {
        
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome não informado");;
            RuleFor(x => x.Valor).NotEmpty().WithMessage("Valor não informado");;
        }
        
    }
}