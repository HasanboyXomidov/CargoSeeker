using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.Auth;

public class VerificationCodeExpiredException:ExpiredException
{
    public VerificationCodeExpiredException()
    {
        this.TitleMessage = "Verification Code Expired !";
    }
}
