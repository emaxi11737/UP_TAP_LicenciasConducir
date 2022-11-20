using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.DTOs;

namespace UP_TAP_LicenciasConducir.Infrastructure.Validators
{
    public class QuestionValidator : AbstractValidator<QuestionDto>
    {
        public QuestionValidator()
        {
            RuleFor(question => question.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(question => question.Description)
                .Length(10, 500)
                .WithMessage("La longitud del la descripcion debe estar entre 10 y 500 caracteres");

            RuleFor(question => question.Answer.Count)
                .InclusiveBetween(2,4)
                .WithMessage("Debe incluir entre 2 y 4 preguntas");


            RuleFor(question => question.Answer.Any(x=> !x.IsRight))
                .Equal(true)
                .WithMessage("Debe incluir al menos una respuesta incorrecta");

            RuleFor(question => question.Answer.Count(x => x.IsRight))
                .Equal(1)
                .WithMessage("Debe incluir una respuesta correcta");

        }
    }
}
