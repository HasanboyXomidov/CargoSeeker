using CargoSeeker.Service.DTO.Users;
using CargoSeeker.Service.Interfaces.Users;
using CargoSeeker.Service.Validators.UserValidators;
using Microsoft.AspNetCore.Mvc;

namespace CargoSeeker.WebApi.Controllers;
[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userservice;
    private readonly int maxPageSize = 30;
    public UsersController(IUserService service)
    {
        _userservice = service;
    }
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromForm] UserCreateDto dto)
    {
        var createValidator = new UserCreateValidator();
        var result = createValidator.Validate(dto);
        if(result.IsValid) { return Ok(await _userservice.CreateAsync(dto)); }
        else return BadRequest(result.Errors);
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

