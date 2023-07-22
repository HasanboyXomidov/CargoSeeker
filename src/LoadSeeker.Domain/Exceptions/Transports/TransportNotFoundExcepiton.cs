using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.Transports;

public class TransportNotFoundExcepiton:NotFoundException
{
    public TransportNotFoundExcepiton()
    {
        this.TitleMessage = "Transport Not Found !";
    }
}
