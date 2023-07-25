using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.Auth;

public class VerificationTooManyRequestException : TooManyRequestExceptions
{
    public VerificationTooManyRequestException()
    {
        TitleMessage = "Too Many Requests!";
    }
}
