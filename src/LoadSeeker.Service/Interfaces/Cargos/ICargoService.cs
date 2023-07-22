using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.DataAccess.ViewModels.Users;
using CargoSeeker.Domain.Entities.Cargos;
using CargoSeeker.Service.DTO.Cargo;
using CargoSeeker.Service.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Cargos;

public interface ICargoService
{
    
    public Task<bool> CreateAsync(CargoCreateDto dto);
    public Task<bool> DeleteAsync(long CargoId);
    public Task<long> CountAsync();
    public Task<IList<CargosViewModel>> GetAllAsync(PaginationParams @params);    
    public Task<bool> UpadteAsync(long CargoId,CargoUpdateDto dto);
    public Task<Cargo> GetBydIdAsync (long CargoId);    

}
