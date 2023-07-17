using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Interfaces.Commons;

public interface IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
}
