using Desafio.Bravi.Domain.Models;
using FluentValidation;

namespace Desafio.Bravi.Api.Controllers.CriarCliente
{
    public class CriarClienteValidator : AbstractValidator<CriarClienteRequest>
    {
        public CriarClienteValidator()
        {
            RuleFor(p => p.Nome)
                .NotEqual("string")
                .NotEmpty();

            RuleFor(p => p.Telefone)
                .SetValidator(new CriarClienteValidatorInnerTelefone())
                .When(p => p.Telefone != null);

            RuleFor(p => p.Email)
                .NotEqual("string")
                .When(p => !string.IsNullOrEmpty(p.Email));

            RuleFor(p => p.WhatsApp)
                .SetValidator(new CriarClienteValidatorInnerTelefone())
                .When(p => p.WhatsApp != null);
        }
    }

    public class CriarClienteValidatorInnerTelefone : AbstractValidator<Telefone>
    {
        public CriarClienteValidatorInnerTelefone()
        {
            RuleFor(p => p.CodigoDiscagem).GreaterThan(0).WithMessage("'CodigoDiscagem' deve ser maior que 0");

            RuleFor(p => p.Numero)
                .NotEqual("string")
                .NotEmpty();
        }
    }
}
