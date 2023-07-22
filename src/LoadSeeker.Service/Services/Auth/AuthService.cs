using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.Domain.Exceptions.UserExceptions;
using CargoSeeker.Service.DTO.Auth;
using CargoSeeker.Service.Interfaces.Auth;
using CargoSeeker.Service.Interfaces.Notifications;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUsersRepository _usersRepository;
    //private readonly ISmsSender _smsSender;
    private readonly int CASHED_MINUTES_FOR_REGISTER = 60;
    private readonly int CASHED_MINUTES_FORvERIFICATION = 5;
    private const string REGISTER_CASHE_KEY = "register_";
    private const string VERIFY_REGISTER_CASHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    public AuthService(IMemoryCache memoryCache,IUsersRepository usersRepository
        )//ISmsSender smsSender
    {
        this._memoryCache = memoryCache;
        this._usersRepository = usersRepository;
        //this._smsSender = smsSender;
    }
    public async Task<(bool Result, int CashedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _usersRepository.GetByPhoneAsync(dto.tel_number);
        if (user is not null ) { throw new UserAlreadyExistsException(dto.tel_number); }

        //if (_memoryCache.TryGetValue(REGISTER_CASHE_KEY + dto.tel_number, out RegisterDto cashedRegisterDto))
        //{
        //   // cashedRegisterDto.first_name = cashedRegisterDto.first_name;
        //    //_memoryCache.Remove(dto.tel_number);
        //}
        //else _memoryCache.Set(REGISTER_CASHE_KEY + dto.tel_number, dto, TimeSpan.FromMinutes(CASHED_MINUTES_FOR_REGISTER));
        return (Result:true, CashedMinutes:CASHED_MINUTES_FOR_REGISTER);


    }

    public Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int Code)
    {
        throw new NotImplementedException();
    }
}
