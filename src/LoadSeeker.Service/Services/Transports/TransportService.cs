using CargoSeeker.DataAccess.Interfaces.Transports;
using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Transports;
using CargoSeeker.Domain.Entities.Transports;
using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Domain.Exceptions.Transports;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.DTO.Transports;
using CargoSeeker.Service.Interfaces.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.Transports;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _transportService;


    public TransportService(ITransportRepository transportService)
    {
        this._transportService = transportService;
    }
    public async Task<long> CountAsync()=>await _transportService.CountAsync();
    public async Task<bool> CreateAsync(TransportCreateDto dto)
    {
        Transport transport = new Transport()
        {
           userId=dto.userid,
           Bodytype=dto.bodytype.ToString(),
           BodyCapacity=dto.BodyCapacity,
           BodyVolume=dto.BodyVolume,
           BodyLength=dto.BodyLength,
           BodyWidth=dto.BodyWidth,
           BodyHeight=dto.BodyHeight,
           Permission = dto.Permission.ToString(),
           StartingLocation=dto.StartingLocation,
           EndingLocation=dto.EndingLocation,
           StartingTime=dto.StartingTime,
           ArchivizeAfterDay=dto.ArchivizeAfterDay,
           Payment=dto.Payment.ToString(),
           isActive=dto.isActive,
           created_at=TimeHelpers.GetDateTime(),
           updated_at=TimeHelpers.GetDateTime()
        };
        var result = await _transportService.CreateAsync(transport);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long TransportId)
    {
        var result = await _transportService.DeleteAsync(TransportId);
        return result > 0;
    }

    public async Task<IList<TransportViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _transportService.GetAllAsync(@params);
        return result; 
    }

    public async Task<Transport> GetBydIdAsync(long transportId)
    {
        var result = await _transportService.GetByIdAsync(transportId);
        if (result == null) throw new TransportNotFoundExcepiton();
        return result;
    }

    public async Task<bool> UpdateAsync(long transportId, TransportsUpdateDto dto)
    {
        var transport = await _transportService.GetByIdAsync(transportId);
        if (transport == null) throw new TransportNotFoundExcepiton();
        transport.userId = dto.userid;
        transport.Bodytype = dto.bodytype.ToString();
        transport.BodyCapacity = dto.BodyCapacity;
        transport.BodyVolume = dto.BodyVolume;
        transport.BodyLength = dto.BodyLength;
        transport.BodyWidth = dto.BodyWidth;
        transport.BodyHeight = dto.BodyHeight;
        transport.Permission = dto.Permission.ToString();
        transport.StartingLocation = dto.StartingLocation;
        transport.EndingLocation = dto.EndingLocation;
        transport.StartingTime = dto.StartingTime;
        transport.ArchivizeAfterDay = dto.ArchivizeAfterDay;
        transport.Payment = dto.Payment.ToString();
        transport.isActive = dto.isActive;        
        transport.updated_at = TimeHelpers.GetDateTime();

        var result = await _transportService.UpdateAsync(transportId, transport);
        return result>0;
    }
}
