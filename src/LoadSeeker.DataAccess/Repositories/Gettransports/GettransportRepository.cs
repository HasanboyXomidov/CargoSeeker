using CargoSeeker.DataAccess.Interfaces.IGettransportsl;
using CargoSeeker.Domain.Entities.GetTransports;
using CargoSeeker.Domain.Entities.Transports;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Repositories.Gettransports;

public class GettransportRepository : BaseRepository, IGettransport
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from gettransport;";
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

    public async Task<int> CreateAsync(GetTransport entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.gettransport(transport_id, cargo_id, is_accepted, status, description, " +
                "bid, distance_type, agreement_day, created_at, updated_at) " +
                "VALUES (@transport_id,@cargoId,@is_accepted,@status,@description,@bid,@distance_Type,@agreement_Day," +
                "@created_at,@updated_at);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM public.gettransport WHERE id={id};";
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

    public async Task<GetTransport?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM public.gettransport WHERE id={id};";
            var result = await _connection.QuerySingleAsync<GetTransport>(query);
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

    public async Task<int> UpdateAsync(long Id, GetTransport entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.gettransport " +
                "SET id=?, transport_id=?, cargo_id=?, is_accepted=?, status=?, description=?, bid=?, distance_type=?," +
                " agreement_day=?, created_at=?, updated_at=? " +
                $"WHERE id={Id};";
            var result = await _connection.ExecuteAsync(query, entity);
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
