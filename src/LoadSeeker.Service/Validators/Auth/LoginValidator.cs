using CargoSeeker.Service.DTO.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.Auth;

public class LoginValidator:AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.Tel_number).Must(phone => PhoneNumberValidaotor.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
