using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Interfaces;

    public interface IRepository<TEntity,TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);
    public Task<int> UpdateAsync(long Id,TEntity entity);
    public Task<int> DeleteAsync(long id);
    public Task<TEntity?> GetByIdAsync(long id);
    public Task<long> CountAsync();
}
