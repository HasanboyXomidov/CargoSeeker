using CargoSeeker.DataAccess.Interfaces.Cargos;
using CargoSeeker.DataAccess.Utils;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.Domain.Entities.Cargos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Repositories.Cargos;

public class CargoRepository : BaseRepository, ICargoRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from cargo;";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;  
        }
        catch 
        {
            return 0;            
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> CreateAsync(Cargo entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.cargo(userid, cargo, cargo_weight, cargo_volume, startingtime, day_after_archive, startloadingplace, loadinglattitude, loadinglongtitude, finishunloadingplace, unloadinglattitude, unloadinglongtitude, bodytype, bid, payment_type, description, postcargoafterminut, is_active, created_at, updated_at) " +
                "VALUES (@userId,@cargo,@cargo_Weight,@cargo_Volume,@startingTime,@day_after_archive," +
                "@StartLoadingPlace,@LoadingLattitude,@LoadingLongtitude," +
                " @FinishUnloadingPlace,@UnloadingLattitude,@UnloadingLongtitude," +
                "@BodyType,@Bid,@payment_type,@description," +
                "@PostCargoAfterMinut,@is_active,@created_at,@updated_at);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from cargo where id={id}";
            var result = await _connection.ExecuteAsync(query);
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

    public async Task<IList<CargosViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from cargos_view where is_active = true order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<CargosViewModel>(query)).ToList();
            return result;
        }
        catch 
        {
            return new List<CargosViewModel>();            
        }
        finally { await _connection.CloseAsync(); } 
    }

    public async Task<Cargo?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from cargo where id={id}";
            var result = await _connection.QuerySingleAsync<Cargo>(query);
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

    public Task<(int ItemsCount, IList<CargosViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long Id, Cargo entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.cargo " +
                $"SET userid=@userId, cargo=@cargo, cargo_weight=@cargo_Weight,cargo_volume=@cargo_Volume, " +
                $"startingtime=@startingTime, day_after_archive=@day_after_archive,startloadingplace=@StartLoadingPlace, " +
                $"loadinglattitude=@LoadingLattitude,loadinglongtitude=@LoadingLongtitude, " +
                $"finishunloadingplace=@FinishUnloadingPlace," +
                $"unloadinglattitude=@UnloadingLattitude, unloadinglongtitude=@UnloadingLongtitude," +
                $"bodytype=@BodyType, bid=@Bid," +
                $" payment_type=@payment_type,description=@description, postcargoafterminut=@PostCargoAfterMinut," +
                $"is_active=@is_active,updated_at=@updated_at " +
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
            await _connection.CloseAsync() ;
        }
    }
}
