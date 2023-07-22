using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.DataAccess.ViewModels.Users;
using CargoSeeker.Domain.Entities.Users;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUsersRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, second_name, country, tel_number, email, password_hash, salt, user_photo_path, status,rating, lattitude, longtitude, created_at, updated_at) " +
                            "VALUES (@first_name, @second_name, @country, @tel_number,@email, @passwordHash, @salt, @userPhotoPath,@status,@rating, @lattitude, @longtitude,@created_at, @updated_at);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;

        }
        catch 
        {
            return 0;            
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM public.users " +
                $"WHERE id={id};";
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

    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users where id=@Id;";
            var result = await _connection.QuerySingleAsync<User>(query,new {Id=id});
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

    public async Task<User?> GetByPhoneAsync(string phoneNumber)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select * from users where tel_number=@PhoneNumber";
            var result = await _connection.QuerySingleAsync(query,new {PhoneNumber=phoneNumber});
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

    public async Task<int> UpdateAsync(long Id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.users SET first_name=@first_name, second_name=@second_name, country=@country," +
                " tel_number=@tel_number, email=@email, password_hash=@passwordHash, salt=@salt," +
                " user_photo_path=@userPhotoPath,status=@status, rating=@rating, lattitude=@lattitude, longtitude=@longtitude," +
                "created_at=@created_at, updated_at=@updated_at " +
                $"WHERE id={Id};";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch 
        {
            return 0;
        }
        finally {
            await _connection.CloseAsync();
        }
    }
}
