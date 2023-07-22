using CargoSeeker.DataAccess.Commons.Interfaces;
using CargoSeeker.DataAccess.Repositories;
using CargoSeeker.DataAccess.ViewModels.Cargo;
using CargoSeeker.DataAccess.ViewModels.Transports;
using CargoSeeker.Domain.Entities.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Interfaces.Transports;

public interface ITransportRepository : IRepository<Transport, TransportViewModel> ,
    ISearchable<Transport>, IGetAll<TransportViewModel>
{

}
