using CargoSeeker.Service.Validators;
using CargoSeeker.Service.Validators.CargosCreateValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSeeker.UniTest.ValidatorTests.Cargos;

public class CargoCreateValidatorTests
{
    [Theory]
    [InlineData("fruits")]
    [InlineData("vegetables")]
    [InlineData("iron")]
    [InlineData("Truncs")]
    [InlineData("Cars")]
    [InlineData("Working Tools")]
    [InlineData("Animals")]
    public void ShouldReturnCorrectCargoName(string cargoName)
    {        
    }
}
