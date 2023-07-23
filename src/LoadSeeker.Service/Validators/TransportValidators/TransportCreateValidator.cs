using CargoSeeker.Service.DTO.Transports;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Validators.TransportValidators;

public class TransportCreateValidator:AbstractValidator<TransportCreateDto>
{
    public TransportCreateValidator()
    {
        RuleFor(dto => dto.userid).NotEmpty().WithMessage("User Id Can not be Empty!");
        RuleFor(dto => dto.bodytype).NotEmpty().WithMessage("Body Type field is required!");
        RuleFor(dto => dto.BodyCapacity).NotEmpty().NotNull().WithMessage("Body Capacity is required!");        


    }
}
