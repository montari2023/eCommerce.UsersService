using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email)
            .NotEmpty()
            .WithMessage("Email is Required")
            .EmailAddress().WithMessage("Invalid Email adress format");
        RuleFor(temp => temp.Password)
            .NotEmpty()
            .WithMessage("Password is Required");
           
    }
}
