using CargoSeeker.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
