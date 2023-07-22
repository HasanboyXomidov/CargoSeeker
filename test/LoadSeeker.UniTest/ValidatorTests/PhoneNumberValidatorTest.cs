using CargoSeeker.Service.Validators;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSeeker.UniTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998901234578")]
    [InlineData("+998902723595")]
    [InlineData("+998332723501")]
    [InlineData("+998902723470")]
    [InlineData("+998551237474")]
    [InlineData("+998901234567")]
    public void ShouldReturnCorrect(string phoneNumber)
    {
        var result = PhoneNumberValidaotor.IsValid(phoneNumber);
        Assert.True(result);    
    }
    [Theory]
    [InlineData("998915687878")]
    [InlineData("914579887")]
    [InlineData("+998 97 123 45 65")]
    [InlineData("+998 33 155 45 65")]
    [InlineData("asdfq123123asdfq")]
    [InlineData("+AAAAAQQQWWWEEE")]
    [InlineData("+998 911234514")]
    [InlineData("-998911161605")]
    public void ShouldReturnWrongAnswer(string phone)
    {
        var result = PhoneNumberValidaotor.IsValid(phone);
        Assert.False(result);
    }

}
