using CargoSeeker.Service.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto dto);
    public Task<bool> UpdateAsync(long UserId,UserUpdateDto dto);
    public Task<bool> DeleteAsync(long UserId);
    public Task<bool> GetByIdAsync(long UserId);

}
