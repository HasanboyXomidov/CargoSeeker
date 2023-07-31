using CargoSeeker.Service.DTO.GetTransports;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.GetTransportValidator;

public class GetTransportUpdateValidator:AbstractValidator<GetTransportUpdateDto>
{
    public GetTransportUpdateValidator()
    {
        RuleFor(dto => dto.cargoId).NotNull().NotEmpty().WithMessage("Cargo is Required!");
        RuleFor(dto => dto.transportId).NotNull().NotEmpty().WithMessage("Transport is Required!");
    }
}
