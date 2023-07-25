using CargoSeeker.DataAccess.Commons.Interfaces;
using CargoSeeker.DataAccess.ViewModels.GettransportView;
using CargoSeeker.Domain.Entities.GetTransports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.Interfaces.IGettransportsl;

public interface IGettransport:IRepository<GetTransport , GettransportView>    
{
}
