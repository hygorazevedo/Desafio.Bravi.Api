using Desafio.Bravi.Domain.Models;
using FluentValidation;

namespace Desafio.Bravi.Api.Controllers.EditarCliente
{
    public class EditarClienteValidator : AbstractValidator<EditarClienteRequest>
    {
        public EditarClienteValidator()
        {
            RuleFor(p => p.Nome)
                .NotEqual("string")
                .NotEmpty();

            RuleFor(p => p.Telefone)
                .SetValidator(new EditarClienteValidatorInnerTelefone())
                .When(p => p.Telefone != null);

            RuleFor(p => p.Email)
                .NotEqual("string")
                .When(p => !string.IsNullOrEmpty(p.Email));

            RuleFor(p => p.WhatsApp)
                .SetValidator(new EditarClienteValidatorInnerTelefone())
                .When(p => p.WhatsApp != null);
        }
    }

    public class EditarClienteValidatorInnerTelefone : AbstractValidator<Telefone>
    {
        public EditarClienteValidatorInnerTelefone()
        {
            RuleFor(p => p.CodigoDiscagem).GreaterThan(0).WithMessage("'CodigoDiscagem' deve ser maior que 0");

            RuleFor(p => p.Numero)
                .NotEqual("string")
                .NotEmpty();
        }
    }
}
