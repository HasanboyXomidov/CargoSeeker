using CargoSeeker.Service.DTO.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.Auth;

public class RegisterValidator:AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(dto => dto.first_name).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");
        

        RuleFor(dto => dto.tel_number).Must(phone => PhoneNumberValidaotor.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
