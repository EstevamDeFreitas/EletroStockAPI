using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field is required")
                .EmailAddress().WithMessage("Email field must reference a valid email address")
                .MaximumLength(50).WithMessage("Email field has a maximum length of 50 characters");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password field is required")
                .Length(8, 255).WithMessage("Password field has a minimum length of 8 and maximum length of 255 characters");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name field is required")
                .MaximumLength(255).WithMessage("Name field has a maximum length of 255 characters");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender field is required");
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate field is required");
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF field is required")
                .Length(11).WithMessage("CPF field has a minimum and maximum length of 11 characters");
            RuleFor(x => x.PhoneType)
                .NotEmpty().WithMessage("PhoneType field is required")
                .MaximumLength(30).WithMessage("PhoneType field has a maximum length of 30 characters");
            RuleFor(x => x.PhoneCode)
                .NotEmpty().WithMessage("PhoneCode field is required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber field is required");
        }
    }
}
