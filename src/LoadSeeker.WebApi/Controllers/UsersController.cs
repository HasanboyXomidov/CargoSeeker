using CargoSeeker.Service.DTO.Users;
using CargoSeeker.Service.Interfaces.Users;
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
        var createValidator = new 
    }


}

