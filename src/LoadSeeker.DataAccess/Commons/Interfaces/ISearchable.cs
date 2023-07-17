using CargoSeeker.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Commons.Interfaces;

public interface ISearchable<TEntity>
{
    public Task<(int ItemsCount, IList<TEntity>)> SearchAsync(String search, PaginationParams @params);

}
