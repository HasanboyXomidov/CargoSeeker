using CargoSeeker.Service.DTO.Cargo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.CargosValidators;

public class CargosUpdateValidator : AbstractValidator<CargoUpdateDto>
{
    public CargosUpdateValidator()
    {
        RuleFor(dto => dto.cargo).NotNull().NotEmpty().WithMessage("Cargo Name is Required!");
        RuleFor(dto => dto.cargo_Weight).NotNull().NotEmpty().WithMessage("Need Cargo Weight!");
        RuleFor(dto => dto.cargo_Volume).NotNull().NotEmpty().WithMessage("Need Cargo Volume!");
        RuleFor(dto => dto.startingTime).NotNull().NotEmpty().WithMessage("Starting time is Required!");
        RuleFor(dto => dto.day_after_archive).NotNull().NotEmpty().WithMessage("Day is Required!");
        RuleFor(dto => dto.StartLoadingPlace).NotNull().NotEmpty().WithMessage("Loading Place is Required!");
        RuleFor(dto => dto.FinishUnloadingPlace).NotNull().NotEmpty().WithMessage("Unloading Place is Required!");        
        RuleFor(dto => dto.Bid).NotNull().NotEmpty().WithMessage("Bid is Required!");        
        RuleFor(dto => dto.is_active).NotNull().NotEmpty().WithMessage("Activation is Required!");
    }
}
