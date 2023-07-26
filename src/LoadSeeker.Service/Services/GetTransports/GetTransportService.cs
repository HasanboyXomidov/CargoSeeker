using CargoSeeker.DataAccess.Interfaces.IGettransportsl;
using CargoSeeker.DataAccess.Repositories.Gettransports;
using CargoSeeker.Domain.Entities.Cargos;
using CargoSeeker.Domain.Entities.GetTransports;
using CargoSeeker.Domain.Entities.Transports;
using CargoSeeker.Domain.Exceptions.Transports;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.DTO.GetTransports;
using CargoSeeker.Service.Interfaces.GetTransports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.GetTransports;

public class GetTransportService : IGetTransportService
{
    private readonly IGettransport _gettransport;

    public GetTransportService(IGettransport repository)
    {
        this._gettransport = repository;
    }
    public async Task<long> CountAsync()
        =>await _gettransport.CountAsync();                
    public async Task<bool> CreateAsync(GetTransportCreateDto dto)
    {
        GetTransport getTransport = new GetTransport()
        {
            cargoId = dto.cargoId,
            transport_id = dto.transportId,
            is_accepted = dto.is_accepted,
            status = dto.status.ToString(),
            description = dto.description,
            bid = dto.bid,
            distance_Type = dto.distance_Type.ToString(),
            agreement_Day = dto.agreement_Day,
            created_at = TimeHelpers.GetDateTime(),
            updated_at=TimeHelpers.GetDateTime(),
        };
        var result = await _gettransport.CreateAsync(getTransport);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long getTransportId)
    {
        var result = await _gettransport.DeleteAsync(getTransportId);
        return result > 0;
    }
    public async Task<GetTransport> GetBydIdAsync(long getTransportId)
    {
        var result =await _gettransport.GetByIdAsync(getTransportId);
        if (result == null) { throw new TransportNotFoundExcepiton(); }
        else return result;
    }
   

    public async Task<bool> UpadteAsync(long getTransportId, GetTransport dto)
    {
        var transport = await _gettransport.GetByIdAsync(getTransportId);
        if (transport == null) { throw new TransportNotFoundExcepiton(); }

        transport.cargoId = dto.cargoId;
        transport.transport_id = dto.transport_id;
        transport.is_accepted = dto.is_accepted;
        transport.status = dto.status.ToString();
        transport.description = dto.description;
        transport.bid = dto.bid;
        transport.distance_Type = dto.distance_Type.ToString();
        transport.agreement_Day = dto.agreement_Day;
        var result = await _gettransport.UpdateAsync(getTransportId, transport);
        return result > 0;
    }

    public async Task<bool> UpadteAsync(long getTransportId, GetTransportUpdateDto dto)
    {
        var transport = await _gettransport.GetByIdAsync(getTransportId);
        if (transport == null) { throw new TransportNotFoundExcepiton(); }

        transport.cargoId = dto.cargoId;
        transport.transport_id = dto.transportId;
        transport.is_accepted = dto.is_accepted;
        transport.status = dto.status.ToString();
        transport.description = dto.description;
        transport.bid = dto.bid;
        transport.distance_Type = dto.distance_Type.ToString();
        transport.agreement_Day = dto.agreement_Day;
        var result = await _gettransport.UpdateAsync(getTransportId, transport);
        return result > 0;
    }
}
