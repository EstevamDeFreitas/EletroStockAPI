using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.OwnerName)
                .NotEmpty().WithMessage("OwnerName field is required")
                .MaximumLength(255).WithMessage("OwnerName field has a maximum length of 255 characters");
            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("CardNumber field is required")
                .Length(16).WithMessage("CardNumber field has a minimum and maximum length of 16 characters");
            RuleFor(x => x.SecurityCode)
                .NotEmpty().WithMessage("SecurityCode field is required")
                .Length(3).WithMessage("SecurityCode field has a minimum and maximum length of 3 characters");
        }
    }
}
