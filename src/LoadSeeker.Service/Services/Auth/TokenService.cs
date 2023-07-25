using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
        this._config = config.GetSection("Jwt");
    }
    public string GenerateToken(User user)
    {
        var IdentityClaims = new Claim[]
        {
            new Claim("Id",user.Id.ToString()),
            new Claim("first_name",user.first_name.ToString()),
            new Claim(ClaimTypes.MobilePhone,user.tel_number),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var KeyCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        int ExpiresHours = int.Parse(_config["LifeTime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Auidience"],
            claims:IdentityClaims,
            expires:TimeHelpers.GetDateTime().AddHours(ExpiresHours),
            signingCredentials: KeyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
