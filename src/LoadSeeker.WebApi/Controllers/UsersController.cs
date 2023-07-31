using CargoSeeker.Service.DTO.Auth;
using CargoSeeker.Service.DTO.Users;
using CargoSeeker.Service.Interfaces.Auth;
using CargoSeeker.Service.Interfaces.Users;
using CargoSeeker.Service.Validators;
using CargoSeeker.Service.Validators.Auth;
using CargoSeeker.Service.Validators.UserValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoSeeker.WebApi.Controllers;
[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userservice;
    private readonly IAuthService _authService;
    private readonly int maxPageSize = 30;
    public UsersController(IUserService service, IAuthService authService)
    {
        this._userservice = service;
        this._authService = authService;
    }
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult> CreateAsync([FromForm] RegisterDto dto)
    {
        var validator = new RegisterValidator();
        var Result = validator.Validate(dto);
        if (Result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(dto);
            return Ok(new { serviceResult.Result, serviceResult.CashedMinutes });
        }
        else return BadRequest(Result.Errors);
    }
    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string phone)
    {
        var result = PhoneNumberValidaotor.IsValid(phone);
        if (result == false) return BadRequest("Phone Number is Invalid!");

        var serviceResult = await _authService.SendCodeForRegisterAsync(phone);
        return Ok(new { serviceResult.Result, serviceResult.CashedVerificationMinutes });
    }
    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto dto)
    {
        var serviceResult = await _authService.VerifyRegisterAsync(dto.PhoneNumber, dto.Code);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var valResult = validator.Validate(loginDto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(loginDto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
    {
        var updateValidator = new UserUpdateValidator();
        var validationResult=updateValidator.Validate(dto);
        if(validationResult.IsValid) { return Ok(await _userservice.UpdateAsync(userId, dto)); }
        else return BadRequest(validationResult.Errors);
    }
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteAsyncs(long userId)
        => Ok(await _userservice.DeleteAsync(userId));  

    
}

