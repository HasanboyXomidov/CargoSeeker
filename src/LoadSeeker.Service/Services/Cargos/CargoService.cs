using CargoSeeker.DataAccess.Interfaces.Cargos;
using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.Domain.Entities.Cargos;
using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Domain.Exceptions.Cargos;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.DTO.Cargo;
using CargoSeeker.Service.Interfaces.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.Cargos;

public class CargoService : ICargoService
{
    private readonly ICargoRepository _cargoService;

    public CargoService(ICargoRepository cargoService)
    {
        this._cargoService = cargoService;
    }
    public async Task<long> CountAsync()=>await _cargoService.CountAsync();    
    public async Task<bool> CreateAsync(CargoCreateDto dto)
    {
        Cargo cargo = new Cargo()
        {
            userId = dto.userId,
            cargo = dto.cargo,
            cargo_Weight = dto.cargo_Weight,
            cargo_Volume = dto.cargo_Volume,
            startingTime = dto.startingTime,
            day_after_archive = dto.day_after_archive,
            StartLoadingPlace = dto.StartLoadingPlace,
            LoadingLattitude = dto.LoadingLattitude,
            LoadingLongtitude = dto.LoadingLongtitude,            
            FinishUnloadingPlace = dto.FinishUnloadingPlace,
            UnloadingLattitude = dto.UnloadingLattitude,
            UnloadingLongtitude = dto.UnloadingLongtitude,                        
            BodyType = dto.BodyType.ToString(),
            Bid = dto.Bid,
            payment_type = dto.payment_type.ToString(),
            description = dto.description,
            PostCargoAfterMinut = dto.PostCargoAfterMinut,
            is_active = dto.is_active,
            created_at = TimeHelpers.GetDateTime(),
            updated_at = TimeHelpers.GetDateTime()
        };
        var result = await _cargoService.CreateAsync(cargo);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long CargoId)
    {
        var category = await _cargoService.GetByIdAsync(CargoId);
        if (category == null) { throw new CargosNotFoundException(); }

        var result = await _cargoService.DeleteAsync(CargoId);
        return result > 0;
    }

    public async Task<IList<CargosViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _cargoService.GetAllAsync(@params);
        return result;
    }

    public async Task<Cargo> GetBydIdAsync(long CargoId)
    {
        var result = await _cargoService.GetByIdAsync(CargoId);
        if(result == null) { throw new CargosNotFoundException(); }
        else return result;
    }

    public async Task<bool> UpadteAsync(long CargoId, CargoUpdateDto dto)
    {
        var cargo = await _cargoService.GetByIdAsync(CargoId);
        if (cargo == null) { throw new CargosNotFoundException(); }

        cargo.userId = dto.userId;
        cargo.cargo = dto.cargo;
        cargo.cargo_Weight = dto.cargo_Weight;
        cargo.cargo_Volume = dto.cargo_Volume;
        cargo.startingTime = dto.startingTime;
        cargo.day_after_archive = dto.day_after_archive;
        cargo.StartLoadingPlace = dto.StartLoadingPlace;
        cargo.LoadingLattitude = dto.LoadingLattitude;
        cargo.LoadingLongtitude = dto.LoadingLongtitude;        
        cargo.FinishUnloadingPlace = dto.FinishUnloadingPlace;
        cargo.UnloadingLattitude = dto.UnloadingLattitude;
        cargo.UnloadingLongtitude = dto.UnloadingLongtitude;                
        cargo.BodyType = dto.BodyType.ToString();
        cargo.Bid = dto.Bid;
        cargo.payment_type = dto.payment_type.ToString();
        cargo.description = dto.description;
        cargo.PostCargoAfterMinut = dto.PostCargoAfterMinut;
        cargo.is_active = dto.is_active;
        cargo.updated_at = TimeHelpers.GetDateTime();

        var result = await _cargoService.UpdateAsync(CargoId ,cargo);
        return result > 0;

    }
}
