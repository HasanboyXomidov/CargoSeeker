using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions.Cargos;

public class CargosNotFoundException:NotFoundException
{
    public CargosNotFoundException()
    {
        this.TitleMessage = "Cargo Not Found!";
    }
}
