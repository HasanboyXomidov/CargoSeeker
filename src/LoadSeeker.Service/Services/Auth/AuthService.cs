using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.DataAccess.Repositories.Users;
using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Domain.Exceptions.Auth;
using CargoSeeker.Domain.Exceptions.UserExceptions;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.Common.Security;
using CargoSeeker.Service.DTO.Auth;
using CargoSeeker.Service.DTO.Notifications;
using CargoSeeker.Service.DTO.Verifications;
using CargoSeeker.Service.Interfaces.Auth;
using CargoSeeker.Service.Interfaces.Notifications;
using CargoSeeker.Service.Services.Notifications;
using Microsoft.AspNetCore.Identity;
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
    private readonly ITokenService _tokenService;
    private readonly ISmsSender _smsSender;
    private readonly int CASHED_MINUTES_FOR_REGISTER = 60;
    private readonly int CASHED_MINUTES_FORvERIFICATION = 5;
    private const string REGISTER_CASHE_KEY = "register_";
    private const string VERIFY_REGISTER_CASHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    public AuthService(IMemoryCache memoryCache,IUsersRepository usersRepository,
        ISmsSender smsSender,ITokenService tokenService)
    {
        this._memoryCache = memoryCache;
        this._usersRepository = usersRepository;
        this._smsSender = smsSender;
        this._tokenService = tokenService;
    }
    public async Task<(bool Result, int CashedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _usersRepository.GetByPhoneAsync(dto.tel_number);
        if (user is not null) throw new UserAlreadyExistsException(dto.tel_number);

        // delete if exists user by this phone number
        if (_memoryCache.TryGetValue(REGISTER_CASHE_KEY + dto.tel_number, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.first_name = cachedRegisterDto.first_name;
            _memoryCache.Remove(dto.tel_number);
        }
        else _memoryCache.Set(REGISTER_CASHE_KEY + dto.tel_number, dto,
            TimeSpan.FromMinutes(CASHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CASHED_MINUTES_FOR_REGISTER);

    }

    public async Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        if (_memoryCache.TryGetValue(REGISTER_CASHE_KEY + phone, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelpers.GetDateTime();

            // make confirm code as random
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CASHE_KEY + phone, out VerificationDto oldVerifcationDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CASHE_KEY + phone);
            }

            _memoryCache.Set(VERIFY_REGISTER_CASHE_KEY + phone, verificationDto,
                TimeSpan.FromMinutes(CASHED_MINUTES_FORvERIFICATION));

            SmsMessageDto smsMessage = new SmsMessageDto();
            smsMessage.Title = "Cargo Seeker";
            smsMessage.Content = "Your verification code : " + verificationDto.Code;
            smsMessage.Recipent = phone.Substring(1);

            var smsResult = await _smsSender.SendAsync(smsMessage);
            if (smsResult is true) return (Result: true, CachedVerificationMinutes: CASHED_MINUTES_FORvERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new UserCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int Code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CASHE_KEY + phone, out RegisterDto registerDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CASHE_KEY + phone, out VerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestException();
                else if (verificationDto.Code == Code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registerDto);
                    if (dbResult is true)
                    {
                        var user = await _usersRepository.GetByPhoneAsync(phone);
                        string token =  _tokenService.GenerateToken(user);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CASHE_KEY + phone);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CASHE_KEY + phone, verificationDto,
                        TimeSpan.FromMinutes(CASHED_MINUTES_FORvERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new UserCacheDataExpiredException();
    }
    private async Task<bool> RegisterToDatabaseAsync(RegisterDto registerDto)
    {
        var user = new User();
        user.first_name = registerDto.first_name;        
        user.tel_number = registerDto.tel_number;
        user.tel_number_confirmed = true;
        user.email=registerDto.email;
        var hasherResult = PasswordHasher.Hash(registerDto.Password);
        user.passwordHash = hasherResult.Hash;
        user.salt = hasherResult.Salt;

        user.created_at = user.updated_at = user.last_activity = TimeHelpers.GetDateTime();
        //user.IdentityRole = Domain.Enums.IdentityRole.User;

        var dbResult = await _usersRepository.CreateAsync(user);
        return dbResult > 0;
    }
    public async Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto)
    {
        var user = await _usersRepository.GetByPhoneAsync(loginDto.Tel_number);
        if (user is null) throw new UserNotFoundException();

        var hasherResult = PasswordHasher.Verify(loginDto.Password, user.passwordHash, user.salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenService.GenerateToken(user);
        return (Result: true, Token: token);
    }
}
