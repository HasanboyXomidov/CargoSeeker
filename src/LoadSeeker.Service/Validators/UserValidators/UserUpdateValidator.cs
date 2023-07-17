using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.DTO.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.UserValidators;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        //Validator for first name
        RuleFor(dto => dto.first_name).NotNull().NotEmpty().WithMessage("Name Field Is Required!")
            .MinimumLength(3).WithMessage("Name Must Be More Than 3 Characters!")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters!");
        // Validator for second name
        RuleFor(dto => dto.second_name).NotNull().NotEmpty().WithMessage("Second Name Field Is Required!")
            .MinimumLength(3).WithMessage("Second Name Must Be More Than 3 Characters!")
            .MaximumLength(50).WithMessage("Second Name must be less than 50 characters!");
        //Validator for Country 
        RuleFor(dto => dto.country).NotNull().NotEmpty().WithMessage("Country Name Field Is Required!")
            .MinimumLength(2).WithMessage("There is no country with characters 2 ")
            .MaximumLength(50).WithMessage("Country name must be less than 50 characters!");
        //Validator for Email
        RuleFor(dto => dto.email).NotNull().NotEmpty().WithMessage("Email is Required!")
            .MinimumLength(15).WithMessage("Email must be more than 15 characters!")
            .MaximumLength(50).WithMessage("Email must be less than 50 characters!")
            .EmailAddress();
        //Validator for Password_hash
        RuleFor(dto => dto.passwordHash).NotNull().NotEmpty().WithMessage("Password Field Is Required!")
            .MinimumLength(3).WithMessage("Password Must Be More Than 9 Characters!")
            .MaximumLength(50).WithMessage("Passwordmust be less than 50 characters!");
        //Validator for Image
        When(dto => dto.userPhotoPath is not null, () =>
        {
            int MaxImageSize = 5;
            RuleFor(dto=>dto.userPhotoPath!.Length).LessThan(MaxImageSize*1024*1024).WithMessage($"Image size must be less than {MaxImageSize} MB");
            RuleFor(dto => dto.userPhotoPath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelpers.GetImageExtencions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });

    }
}
