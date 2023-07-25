using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Common.Security;

public class PasswordHasher
{
    public static (string Hash , string Salt ) Hash ( string Password )
    {
        string salt =Guid.NewGuid().ToString();
        string hash = BCrypt.Net.BCrypt.HashPassword(Password+salt);
        return (Hash:hash,Salt:salt);   
    }
    public static bool Verify(string Password , string hash , string salt  ) 
    {
        return BCrypt.Net.BCrypt.Verify(Password + salt, hash);
    }
}
