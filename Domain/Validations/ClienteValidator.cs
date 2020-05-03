using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome não informado");;
            RuleFor(x => x.SobreNome).NotEmpty().WithMessage("Sobrenome não informado");;
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email invalido");;
        }
        
    }
}