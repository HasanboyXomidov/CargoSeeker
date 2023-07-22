using CargoSeeker.DataAccess.Utils;
using CargoSeeker.Service.DTO.Cargo;
using CargoSeeker.Service.Interfaces.Cargos;
using CargoSeeker.Service.Validators.CargosValidators;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CargoSeeker.WebApi.Controllers;

[Route("api/cargos")]
[ApiController]
public class CargoController : ControllerBase
{
    private readonly ICargoService _cargoService;
    private readonly int MaxPageSize = 30;
    public CargoController(ICargoService cargoService)
    {
        this._cargoService = cargoService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1) =>
        Ok(await _cargoService.GetAllAsync(new PaginationParams(page, MaxPageSize)));

    [HttpGet("{cargoId}")]
    public async Task<IActionResult> GetByIdAsync(long cargoId)=>
        Ok(await _cargoService.GetBydIdAsync(cargoId));
    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()=>Ok(await _cargoService.CountAsync());
    [HttpPost]
    public async Task<IActionResult> CreateAscyn([FromForm] CargoCreateDto dto)=>Ok(await _cargoService.CreateAsync(dto));
    [HttpPut("{cargoId}")]
    public async Task<IActionResult> UpadteAsync(long cargoId, [FromForm] CargoUpdateDto dto)
    {
        var updateValidator = new CargosUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) { return Ok(await _cargoService.UpadteAsync(cargoId, dto)); }
        else return BadRequest(validationResult.Errors);
    }
    [HttpDelete("{cargoId}")]
    public async Task<IActionResult> DeleteAsync(long cargoId)=>Ok(await _cargoService.DeleteAsync(cargoId));
}
