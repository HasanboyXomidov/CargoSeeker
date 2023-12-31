﻿using CargoSeeker.Domain.Entities.Cargos;
using CargoSeeker.Domain.Entities.GetTransports;
using CargoSeeker.Service.DTO.Cargo;
using CargoSeeker.Service.DTO.GetTransports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CargoSeeker.Service.Interfaces.GetTransports;

public interface IGetTransportService
{
    public Task<bool> CreateAsync(GetTransportCreateDto dto);
    public Task<bool> DeleteAsync(long getTransportId);
    public Task<long> CountAsync();
    public Task<bool> UpadteAsync(long getTransportId, GetTransportUpdateDto dto);
    public Task<GetTransport> GetBydIdAsync(long getTransportId);
}
