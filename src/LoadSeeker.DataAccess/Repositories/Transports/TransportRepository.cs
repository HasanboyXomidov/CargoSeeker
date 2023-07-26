using CargoSeeker.DataAccess.Interfaces.Transports;
using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Transports;
using CargoSeeker.Domain.Entities.Transports;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Repositories.Transports;

public class TransportRepository : BaseRepository, ITransportRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from transport;";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch 
        {
            return 0;            
        }
        finally 
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Domain.Entities.Transports.Transport entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.transport(userid, bodytype, bodycapacity, bodyvolume, bodylength, bodywidth, bodyheight, permission, startinglocation, endinglocation, startingtime, archivizeafterday, payment, is_active, created_at, updated_at) " +
                "VALUES(@userId,@Bodytype,@BodyCapacity,@BodyVolume,@BodyLength,@BodyWidth,@BodyHeight,@Permission,@StartingLocation," +
                "@EndingLocation,@StartingTime,@ArchivizeAfterDay,@Payment,@isActive,@created_at,@updated_at);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch 
        {
            return 0;
        }finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM public.transport WHERE id={id};";
            var result = await _connection.ExecuteAsync(query);
            return result;
        }
        catch 
        {
            return 0;            
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public async Task<IList<TransportViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from transportViewModel order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize};";
            var result = (await _connection.QueryAsync<TransportViewModel>(query)).ToList();
            return result;  
        }
        catch 
        {
            return new List<TransportViewModel>();            
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Domain.Entities.Transports.Transport?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from transport where id = {id}";
            var result = await _connection.QuerySingleAsync<Transport>(query);
            return result;  
        }
        catch 
        {
            return null;
            
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<(int ItemsCount, IList<Domain.Entities.Transports.Transport>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from transport " +
                $" where bodytype ilike '%{search}% " +
                $"order by id desc " +
                $"offset{@params.GetSkipCount()} limit{@params.PageSize};";
            var result = (await _connection.QueryAsync<Transport>(query)).ToList();
            return (result.Count, result);
        }
        catch 
        {
            return( 0,new List<Transport>());            
        }
        finally { 
        await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long Id, Domain.Entities.Transports.Transport entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.gettransport " +
                "SET transport_id=@transportId, cargo_id=@cargoId, is_accepted=@is_accepted, status=@status," +
                "description=@description, bid=@bid," +
                "distance_type=@distance_Type, agreement_day=@agreement_Day,updated_at=@updated_at " +
                $"WHERE id={Id};";
            var result = await _connection.ExecuteAsync(query,entity);
            return result;
        }
        catch 
        {
            return 0;

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
