using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Exceptions;

public class BadRequestException:Exception
{
    public HttpStatusCode StatusCode {  get; set; }  = HttpStatusCode.BadRequest;
    public string TitleMessage { get; set; }   = string.Empty;

}
