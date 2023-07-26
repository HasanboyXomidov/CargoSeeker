using CargoSeeker.Domain.Entities.GetTransports;
using CargoSeeker.Service.DTO.GetTransports;
using CargoSeeker.Service.Interfaces.GetTransports;
using CargoSeeker.Service.Validators.GetTransportValidator;
using Microsoft.AspNetCore.Mvc;

namespace CargoSeeker.WebApi.Controllers;
[Route("api/gettransport")]
[ApiController]
public class GetTransportController:ControllerBase
{
    private readonly IGetTransportService _getTransportService;
    private readonly int MaxPageSize = 30;
    public GetTransportController(IGetTransportService getTransportService)
    {
        this._getTransportService = getTransportService;
    }
    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()=>Ok(await _getTransportService.CountAsync());
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] GetTransportCreateDto dto)
    {
        var getTransportValidator = new GetTransportCreateValidator();
        var validationResult= getTransportValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _getTransportService.CreateAsync(dto));
        else return BadRequest(validationResult.Errors);
    }

}
