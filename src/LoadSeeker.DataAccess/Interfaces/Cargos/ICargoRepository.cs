using CargoSeeker.DataAccess.Commons.Interfaces;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.Domain.Entities.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Interfaces.Cargos;

public interface ICargoRepository:IRepository<Cargo , CargosViewModel>,
    ISearchable<CargosViewModel>,IGetAll<Cargo>
{

}
