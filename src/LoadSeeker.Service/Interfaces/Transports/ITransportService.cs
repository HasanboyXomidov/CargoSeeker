using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.DataAccess.ViewModels.Transports;
using CargoSeeker.Domain.Entities.Cargos;
using CargoSeeker.Domain.Entities.Transports;
using CargoSeeker.Service.DTO.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Transports;

public interface ITransportService
{
    public Task<bool> CreateAsync(TransportCreateDto dto);
    public Task<bool> DeleteAsync(long TransportId);
    public Task<bool> UpdateAsync(long transportId,TransportsUpdateDto dto);
    public Task<Transport> GetBydIdAsync(long TransportID);
    public Task<long> CountAsync();
    public Task<IList<TransportViewModel>> GetAllAsync(PaginationParams @params);

}
