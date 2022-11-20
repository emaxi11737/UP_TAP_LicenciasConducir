using FluentValidation;
using UP_TAP_LicenciasConducir.Core.DTOs;

namespace UP_TAP_LicenciasConducir.Infrastructure.Validators
{
    public class AnswerValidator : AbstractValidator<AnswerDto>
    {
        public AnswerValidator()
        {
            RuleFor(answer => answer.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(answer => answer.Description)
                .Length(1, 500)
                .WithMessage("La longitud del la descripcion debe estar entre 1 y 500 caracteres");

            RuleFor(answer => answer.QuestionId)
                .NotNull()
                .WithMessage("Debe incluir un id");

            RuleFor(answer => answer.IsRight)
                .NotNull()
                .WithMessage("Campo IsRight nulo");


        }
    }
}
