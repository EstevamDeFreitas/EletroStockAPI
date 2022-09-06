using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CardFlagValidator : AbstractValidator<CardFlag>
    {
        public CardFlagValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name field is required")
                .MaximumLength(32).WithMessage("Name field has a maximum length of 32 characters");
        }
    }
}
