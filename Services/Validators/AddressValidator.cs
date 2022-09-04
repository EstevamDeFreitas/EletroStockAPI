using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.AddressType)
                .NotEmpty().WithMessage("AddressType field is required")
                .MaximumLength(40).WithMessage("AddressType field has a maximum length of 40 characters");
            RuleFor(x => x.CEP)
                .NotEmpty().WithMessage("CEP field is required")
                .Length(8).WithMessage("CEP field has a minimum and maximum length of 8 characters");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City field is required")
                .MaximumLength(255).WithMessage("City field has a maximum length of 255 characters");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country field is required")
                .MaximumLength(50).WithMessage("Country field has a maximum length of 50 characters");
            RuleFor(x => x.Description)
                .MaximumLength(255).When(x => x.City is not null).WithMessage("Description field has a maximum length of 255 characters");
            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District field is required")
                .MaximumLength(50).WithMessage("District field has a maximum length of 50 characters");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number field is required");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State field is required")
                .Length(2).WithMessage("State field has a minimum and maximum length of 2 characters");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street field is required")
                .MaximumLength(255).WithMessage("Street field has a maximum length of 255 characters");
            RuleFor(x => x.StreetType)
                .NotEmpty().WithMessage("StreetType is required")
                .MaximumLength(40).WithMessage("StreeetType field has a maximum length of 40 characters");
        }
    }
}
