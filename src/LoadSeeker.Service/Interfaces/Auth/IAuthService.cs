using CargoSeeker.Service.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CashedMinutes)> RegisterAsync(RegisterDto dto);
    public Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string phone);
    public Task<(bool Result , string Token)> VerifyRegisterAsync(string phone,int Code);
    public Task<(bool Result,string Token)> LoginAsync (LoginDto loginDto);    
}
