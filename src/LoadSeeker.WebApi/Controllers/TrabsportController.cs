using CargoSeeker.DataAccess.Utils;
using CargoSeeker.Service.DTO.Cargo;
using CargoSeeker.Service.DTO.Transports;
using CargoSeeker.Service.Interfaces.Transports;
using CargoSeeker.Service.Validators.TransportValidators;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CargoSeeker.WebApi.Controllers;

[Route("api/transports")]
[ApiController]
public class TransportController:ControllerBase
{
    private readonly ITransportService _transportService;
    private readonly int MaxPageSize = 30;
    public TransportController(ITransportService _service)
    {
        this._transportService = _service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery]int page =1 )
        =>Ok(await _transportService.GetAllAsync(new PaginationParams(page,MaxPageSize)));
    [HttpGet("{transportId}")]
    public async Task<IActionResult> GetByIdAsync(long transportId)
        =>Ok(await _transportService.GetBydIdAsync(transportId));
    [HttpGet("count")]
    public async Task<IActionResult> CountTransportAsync()=>Ok(await _transportService.CountAsync());
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] TransportCreateDto dto)=>
        Ok(await _transportService.CreateAsync(dto));
    [HttpPut("{transportId}")]
    public async Task<IActionResult> UpdateAsync(long transportId, [FromForm]TransportsUpdateDto dto)
    {
        var updateValidator = new TransportUpdateValidator();
        var validationResult = updateValidator.Validate(dto);  
        if(validationResult.IsValid) { return Ok(await _transportService.UpdateAsync(transportId, dto)); }
        else return BadRequest(validationResult.Errors);   
    }
    [HttpDelete("{transportId}")]
    public async Task<IActionResult> DeleteAsync(long transportId)=>Ok(await _transportService.DeleteAsync(transportId));   
}
