using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions;

public class ExpiredException:Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Gone;
    public string TitleMessage { get; set; } = string.Empty;

}
